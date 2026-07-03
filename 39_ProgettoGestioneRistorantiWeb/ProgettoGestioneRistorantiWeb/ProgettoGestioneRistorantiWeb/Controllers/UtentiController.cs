using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoGestioneRistorantiWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UtentiController : ControllerBase
{
    private readonly IUtentiRepository _repository;

    public UtentiController(IUtentiRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Utente>>> GetAll()
    {
        var utenti = await _repository.GetAllAsync();
        return Ok(utenti);
    }

    [HttpGet("{userName}")]
    public async Task<ActionResult<Utente>> GetByUserName(string userName)
    {
        var utente = await _repository.GetByUserNameAsync(userName);
        if (utente is null)
        {
            return NotFound();
        }

        return Ok(utente);
    }

    [HttpPost]
    public async Task<ActionResult<Utente>> Create(Utente utente)
    {
        await _repository.AddAsync(utente);
        return CreatedAtAction(nameof(GetByUserName), new { userName = utente.UserName }, utente);
    }

    [HttpPut("{userName}")]
    public async Task<IActionResult> Update(string userName, Utente utente)
    {
        if (!string.Equals(userName, utente.UserName, StringComparison.OrdinalIgnoreCase))
        {
            return BadRequest();
        }

        var existing = await _repository.GetByUserNameAsync(userName);
        if (existing is null)
        {
            return NotFound();
        }

        await _repository.UpdateAsync(utente);
        return NoContent();
    }

    [HttpDelete("{userName}")]
    public async Task<IActionResult> Delete(string userName)
    {
        var existing = await _repository.GetByUserNameAsync(userName);
        if (existing is null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(userName);
        return NoContent();
    }
}


/*
 CreatedAtAction() è un metodo di ASP.NET Core che restituisce una risposta HTTP 201 Created e, oltre ai dati creati, indica al client dove può recuperare la nuova risorsa.
 * 
 */