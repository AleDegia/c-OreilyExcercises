using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IPrenotazioniRepository
{
    Task<List<Prenotazione>> GetAllAsync();

    Task<Prenotazione?> GetByIdAsync(int id);

    Task<List<Prenotazione>> GetByRistoranteIdAsync(int ristoranteId);

    Task<List<Prenotazione>> GetByNomeUtenteAsync(string nomeUtente);

    Task AddAsync(Prenotazione prenotazione);

    Task UpdateAsync(Prenotazione prenotazione);

    Task DeleteAsync(int id);
}
