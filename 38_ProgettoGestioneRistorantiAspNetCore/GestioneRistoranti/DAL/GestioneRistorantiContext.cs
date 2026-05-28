using Microsoft.EntityFrameworkCore;
using Models;

namespace DALe
{
    public class GestioneRistorantiContext : DbContext
    {
        public GestioneRistorantiContext(
            DbContextOptions<GestioneRistorantiContext> options)
            : base(options)
        {
        }

        public DbSet<Utente> Utenti { get; set; }

        public DbSet<Ristorante> Ristoranti { get; set; }

        public DbSet<Prenotazione> Prenotazioni { get; set; }
    }
}
