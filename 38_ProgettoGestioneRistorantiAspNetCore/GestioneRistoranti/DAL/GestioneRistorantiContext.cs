using Microsoft.EntityFrameworkCore;
using Models;

namespace DATA
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

        public DbSet<Tipologie> Tipologie { get; set; }

        public DbSet<LogPrenotazione> LogPrenotazioni { get; set; }
    }
}
