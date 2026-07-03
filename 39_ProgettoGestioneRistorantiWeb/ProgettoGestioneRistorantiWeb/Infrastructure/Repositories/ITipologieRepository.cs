using Domain.Entities;

namespace Infrastructure.Repositories;

public interface ITipologieRepository
{
    Task<List<Tipologia>> GetAllAsync();

    Task<Tipologia?> GetByIdAsync(int id);

    Task AddAsync(Tipologia tipologia);

    Task UpdateAsync(Tipologia tipologia);

    Task DeleteAsync(int id);
}
