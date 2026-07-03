using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UtentiRepository : IUtentiRepository
{
    private readonly GestioneRistorantiDbContext _context;

    public UtentiRepository(GestioneRistorantiDbContext context)
    {
        _context = context;
    }

    public async Task<List<Utente>> GetAllAsync()
    {
        return await _context.Utenti.ToListAsync();
    }

    public async Task<Utente?> GetByUserNameAsync(string userName)
    {
        return await _context.Utenti.FindAsync(userName);
    }

    public async Task AddAsync(Utente utente)
    {
        _context.Utenti.Add(utente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Utente utente)
    {
        _context.Utenti.Update(utente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string userName)
    {
        var utente = await _context.Utenti.FindAsync(userName);
        if (utente is null)
        {
            return;
        }

        _context.Utenti.Remove(utente);
        await _context.SaveChangesAsync();
    }
}
