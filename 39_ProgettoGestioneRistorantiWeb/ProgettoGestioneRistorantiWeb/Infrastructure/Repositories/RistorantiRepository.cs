using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repositories;

public class RistorantiRepository : IRistorantiRepository
{
    private readonly GestioneRistorantiDbContext _context;

    public RistorantiRepository(GestioneRistorantiDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ristorante>> GetAllAsync(int? limit )
    {
        var query = _context.Ristoranti
       .OrderBy(r => r.Id)
       .AsQueryable();

        if (limit.HasValue)
        {
            query = query.Take(limit.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<List<Ristorante>> GetAllByUsernameAsync(string username)
    {
        return await _context.Ristoranti.Where(r => r.UsernameProprietario == username).ToListAsync();
    }

    public async Task<Ristorante?> GetByIdAsync(int id)
    {
        return await _context.Ristoranti.FindAsync(id);
    }

    public async Task AddAsync(Ristorante ristorante)
    {
        _context.Ristoranti.Add(ristorante);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ristorante ristorante)
    {
        _context.Ristoranti.Update(ristorante);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {   
        var ristorante = await _context.Ristoranti.FindAsync(id);
        if (ristorante is null)
        {
            return;
        }

        _context.Ristoranti.Remove(ristorante);
        await _context.SaveChangesAsync();
    }
}
