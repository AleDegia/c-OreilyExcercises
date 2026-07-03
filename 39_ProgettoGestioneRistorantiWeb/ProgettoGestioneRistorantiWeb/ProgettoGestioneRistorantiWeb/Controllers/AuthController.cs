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
            utente.IsAdministrator = false;                          // Imposta l'utente come non amministratore per default
            await _repository.AddAsync(utente);
            utente.Password = string.Empty;
            return Created($"/api/auth/{utente.UserName}", utente);
        }
    }
}
