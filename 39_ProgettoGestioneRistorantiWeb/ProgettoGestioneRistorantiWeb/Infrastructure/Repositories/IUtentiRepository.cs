using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IUtentiRepository
{
    Task<List<Utente>> GetAllAsync();

    Task<Utente?> GetByUserNameAsync(string userName);

    Task AddAsync(Utente utente);

    Task UpdateAsync(Utente utente);

    Task DeleteAsync(string userName);
}
