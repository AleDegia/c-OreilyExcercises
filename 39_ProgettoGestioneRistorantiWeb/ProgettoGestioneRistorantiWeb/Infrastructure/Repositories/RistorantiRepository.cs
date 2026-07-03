using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RistorantiRepository : IRistorantiRepository
{
    private readonly GestioneRistorantiDbContext _context;

    public RistorantiRepository(GestioneRistorantiDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ristorante>> GetAllAsync()
    {
        return await _context.Ristoranti.ToListAsync();
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
