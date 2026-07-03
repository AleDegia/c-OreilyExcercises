using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoGestioneRistorantiWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipologieController : ControllerBase
{
    private readonly ITipologieRepository _repository;

    public TipologieController(ITipologieRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Tipologia>>> GetAll()
    {
        var tipologie = await _repository.GetAllAsync();
        return Ok(tipologie);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tipologia>> GetById(int id)
    {
        var tipologia = await _repository.GetByIdAsync(id);
        if (tipologia is null)
        {
            return NotFound();
        }

        return Ok(tipologia);
    }

    [HttpPost]
    public async Task<ActionResult<Tipologia>> Create(Tipologia tipologia)
    {
        await _repository.AddAsync(tipologia);
        return CreatedAtAction(nameof(GetById), new { id = tipologia.Id }, tipologia);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Tipologia tipologia)
    {
        if (id != tipologia.Id)
        {
            return BadRequest();
        }

        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _repository.UpdateAsync(tipologia);
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
