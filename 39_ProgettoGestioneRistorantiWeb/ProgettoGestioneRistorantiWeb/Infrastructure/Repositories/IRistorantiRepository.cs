using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IRistorantiRepository
{
    Task<List<Ristorante>> GetAllAsync();

    Task<Ristorante?> GetByIdAsync(int id);

    Task AddAsync(Ristorante ristorante);

    Task UpdateAsync(Ristorante ristorante);

    Task DeleteAsync(int id);
}
