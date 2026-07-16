using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IRistorantiRepository
{
    Task<List<Ristorante>> GetAllAsync(int? limit);

    Task<List<Ristorante>> GetAllByUsernameAsync(string username);

    Task<Ristorante?> GetByIdAsync(int id);

    Task AddAsync(Ristorante ristorante);

    Task UpdateAsync(Ristorante ristorante);

    Task DeleteAsync(int id);
}
