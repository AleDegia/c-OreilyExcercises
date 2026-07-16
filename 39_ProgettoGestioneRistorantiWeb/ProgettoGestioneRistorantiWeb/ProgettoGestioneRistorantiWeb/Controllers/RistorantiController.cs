using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoGestioneRistorantiWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RistorantiController : ControllerBase
{
    private readonly IRistorantiRepository _repository;

    public RistorantiController(IRistorantiRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Ristorante>>> GetAll([FromQuery] int? limit)
    {
        var ristoranti = await _repository.GetAllAsync(limit);
        return Ok(ristoranti);
    }

    [HttpGet("miei")]
    public async Task<ActionResult<List<Ristorante>>> GetAllByUsername()
    {
        string? username = HttpContext.Session.GetString("UserName");

        // Sessione non presente
        if (string.IsNullOrEmpty(username))
        {
            return Unauthorized("Utente non autenticato.");
        }
        var ristoranti = await _repository.GetAllByUsernameAsync(username);

        if (!ristoranti.Any())
        {
            return NotFound("Nessun ristorante trovato.");
        }
        return Ok(ristoranti);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Ristorante>> GetById(int id)
    {
        var ristorante = await _repository.GetByIdAsync(id);
        if (ristorante is null)
        {
            return NotFound();
        }

        return Ok(ristorante);
    }

    [HttpPost("nuovo")]
    public async Task<ActionResult<Ristorante>> Create(Ristorante ristorante)
    {
        await _repository.AddAsync(ristorante);
        return CreatedAtAction(nameof(GetById), new { id = ristorante.Id }, ristorante);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Ristorante ristorante)
    {
        if (id != ristorante.Id)
        {
            return BadRequest();
        }

        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _repository.UpdateAsync(ristorante);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
