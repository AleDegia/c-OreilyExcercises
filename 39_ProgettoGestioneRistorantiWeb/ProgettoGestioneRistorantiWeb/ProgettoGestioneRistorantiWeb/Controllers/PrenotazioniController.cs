using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoGestioneRistorantiWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrenotazioniController : ControllerBase
{
    private readonly IPrenotazioniRepository _repository;

    public PrenotazioniController(IPrenotazioniRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Prenotazione>>> GetAll()      // ActionResult<List<Prenotazione>> indica che il metodo restituisce una risposta HTTP (ActionResult) che può contenere una lista di oggetti Prenotazione.
    {
        var prenotazioni = await _repository.GetAllAsync();
        return Ok(prenotazioni);                                     //restituisce Json con la lista di prenotazioni
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Prenotazione>> GetById(int id)
    {
        var prenotazione = await _repository.GetByIdAsync(id);
        if (prenotazione is null)
        {
            return NotFound();
        }

        return Ok(prenotazione);
    }

    [HttpGet("ristorante/{ristoranteId:int}")]
    public async Task<ActionResult<List<Prenotazione>>> GetByRistoranteId(int ristoranteId)
    {
        var prenotazioni = await _repository.GetByRistoranteIdAsync(ristoranteId);
        return Ok(prenotazioni);
    }

    [HttpGet("utente/{nomeUtente}")]
    public async Task<ActionResult<List<Prenotazione>>> GetByNomeUtente(string nomeUtente)
    {
        var prenotazioni = await _repository.GetByNomeUtenteAsync(nomeUtente);
        return Ok(prenotazioni);
    }

    [HttpPost]
    public async Task<ActionResult<Prenotazione>> Create(Prenotazione prenotazione)
    {
        prenotazione.DataRichiesta = DateTime.Now;
        await _repository.AddAsync(prenotazione);
        return CreatedAtAction(nameof(GetById), new { id = prenotazione.Id }, prenotazione);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Prenotazione prenotazione)                      //prende id da url e prenotazione dal body della richiesta
    {
        if (id != prenotazione.Id)
        {
            return BadRequest();
        }

        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _repository.UpdateAsync(prenotazione);
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
