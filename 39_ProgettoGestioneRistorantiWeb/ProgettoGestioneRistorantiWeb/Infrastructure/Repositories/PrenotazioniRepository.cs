using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PrenotazioniRepository : IPrenotazioniRepository
{
    private readonly GestioneRistorantiDbContext _context;

    public PrenotazioniRepository(GestioneRistorantiDbContext context)
    {
        _context = context;
    }

    public async Task<List<Prenotazione>> GetAllAsync()
    {
        return await _context.Prenotazioni.ToListAsync();
    }

    public async Task<Prenotazione?> GetByIdAsync(int id)
    {
        return await _context.Prenotazioni.FindAsync(id);
    }

    public async Task<List<Prenotazione>> GetByRistoranteIdAsync(int ristoranteId)
    {
        return await _context.Prenotazioni
            .Where(prenotazione => prenotazione.RistoranteId == ristoranteId)
            .ToListAsync();
    }

    public async Task<List<Prenotazione>> GetByNomeUtenteAsync(string nomeUtente)
    {
        return await _context.Prenotazioni
            .Where(prenotazione => prenotazione.NomeUtente == nomeUtente)
            .ToListAsync();
    }

    public async Task AddAsync(Prenotazione prenotazione)
    {
        _context.Prenotazioni.Add(prenotazione);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Prenotazione prenotazione)
    {
        _context.Prenotazioni.Update(prenotazione);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var prenotazione = await _context.Prenotazioni.FindAsync(id);
        if (prenotazione is null)
        {
            return;
        }

        _context.Prenotazioni.Remove(prenotazione);
        await _context.SaveChangesAsync();
    }
}
