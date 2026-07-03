using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TipologieRepository : ITipologieRepository
{
    private readonly GestioneRistorantiDbContext _context;

    public TipologieRepository(GestioneRistorantiDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tipologia>> GetAllAsync()
    {
        return await _context.Tipologie.ToListAsync();
    }

    public async Task<Tipologia?> GetByIdAsync(int id)
    {
        return await _context.Tipologie.FindAsync(id);
    }

    public async Task AddAsync(Tipologia tipologia)
    {
        _context.Tipologie.Add(tipologia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tipologia tipologia)
    {
        _context.Tipologie.Update(tipologia);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tipologia = await _context.Tipologie.FindAsync(id);
        if (tipologia is null)
        {
            return;
        }

        _context.Tipologie.Remove(tipologia);
        await _context.SaveChangesAsync();
    }
}
