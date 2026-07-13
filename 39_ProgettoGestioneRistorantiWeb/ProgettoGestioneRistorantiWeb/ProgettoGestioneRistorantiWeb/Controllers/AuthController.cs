using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;

namespace ProgettoGestioneRistorantiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUtentiRepository _repository;

        public AuthController(IUtentiRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Utente>> Register(Utente utente)
        {
            var existingUser = await _repository.GetByUserNameAsync(utente.UserName);
            if (existingUser is not null)
            {
                return Conflict("Username already exists.");
            }
            utente.IsAdministrator = false;                                                     // Imposta l'utente come non amministratore per default
            await _repository.AddAsync(utente);
            utente.Password = string.Empty;
            return Created($"/api/auth/{utente.UserName}", utente);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Utente>> Login(LoginRequest request)                     //ricevo LoginRequest perchè arrivano solo username e pass dal login non l'intero utente
        {
            var existingUser = await _repository.GetByUserNameAsync(request.UserName);
            if (existingUser is null || existingUser.Password != request.Password)
            {
                return Unauthorized("Invalid username or password.");
            }
            existingUser.Password = string.Empty; // Non restituire la password
            HttpContext.Session.SetString("UserName", request.UserName);                        //salvo sessione dell'utente loggato
            return Ok(existingUser);
        }

        [HttpGet("check")]
        public ActionResult<bool> CheckIfLogged()                              //sessione viene mandata in automatico tramite cookie
        {
            var user = HttpContext.Session.GetString("UserName");
            if (user != null)
                return Ok(user is not null);
            else
                return BadRequest();
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
