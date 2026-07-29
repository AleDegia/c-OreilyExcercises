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

    //[HttpGet]
    //public async Task<ActionResult<List<Ristorante>>> GetAllRistFiltrati([FiltroRistoranti filtroRist)
    //{
    //    var ristoranti = await _repository.GetAllAsync(limit);
    //    return Ok(ristoranti);
    //}

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
        var username = HttpContext.Session.GetString("UserName");
        ristorante.UsernameProprietario = username;
        await _repository.AddAsync(ristorante);
        return CreatedAtAction(nameof(GetById), new { id = ristorante.Id }, ristorante);
    }

    [HttpPost("{id}/immagine")]
    public async Task<IActionResult> Upload(int id, IFormFile immagine)
    {
        var ristorante = await _repository.GetByIdAsync(id);

        if (ristorante == null)
            return NotFound();

        using var ms = new MemoryStream();

        await immagine.CopyToAsync(ms);

        ristorante.Immagine = ms.ToArray();
        await _repository.UpdateAsync(ristorante);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Ristorante ristorante)          //id da url, ristorante dal body
    {
        if (id != ristorante.Id)                                                    //Controllo in + per coerenza dati
        {
            return BadRequest();
        }

        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        existing.RagioneSociale = ristorante.RagioneSociale;
        existing.PartitaIva = ristorante.PartitaIva;
        existing.Indirizzo = ristorante.Indirizzo;
        existing.TipologiaId = ristorante.TipologiaId;
        existing.NumeroPosti = ristorante.NumeroPosti;
        existing.PrezzoMedio = ristorante.PrezzoMedio;

        await _repository.UpdateAsync(existing);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var username = HttpContext.Session.GetString("UserName");
        if (string.IsNullOrWhiteSpace(username))
        {
            return Unauthorized("Utente non autenticato.");
        }
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }
        // Autorizzazione
        if (existing.UsernameProprietario != username)
        {
            return Forbid();
        }

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}


public class FiltroRistoranti
{
    public string citta { get; set; }
    public string stato { get; set; }
}