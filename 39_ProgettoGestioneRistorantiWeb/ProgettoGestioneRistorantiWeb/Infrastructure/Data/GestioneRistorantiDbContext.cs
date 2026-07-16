using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GestioneRistorantiDbContext : DbContext
{
    //Riceve un oggetto options che contiene tutte le impostazioni del DbContext
    //options Di solito viene creato automaticamente dalla Dependency Injection quando registri il contesto nel Program.cs
    public GestioneRistorantiDbContext(DbContextOptions<GestioneRistorantiDbContext> options)
        : base(options)
    {
    }

    // Set<T>() è un metodo della classe DbContext. dice ma "Restituiscimi il DbSet associato all'entità Utente."
    public DbSet<Utente> Utenti => Set<Utente>();

    public DbSet<Ristorante> Ristoranti => Set<Ristorante>();

    public DbSet<Prenotazione> Prenotazioni => Set<Prenotazione>();

    public DbSet<Tipologia> Tipologie => Set<Tipologia>();

    //OnModelCreating è il metodo in cui configuri come le classi del tuo dominio vengono mappate sulle tabelle del database.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(utente => utente.UserName);
            entity.Property(utente => utente.UserName).HasMaxLength(20);
            entity.Property(utente => utente.Password).HasMaxLength(100).IsRequired();
            entity.Property(utente => utente.Descrizione).HasMaxLength(100);
            entity.Property(utente => utente.Email).HasMaxLength(100).IsRequired();
            entity.Property(utente => utente.Telefono).HasMaxLength(20);
            entity.Property(utente => utente.Citta).HasMaxLength(50);
        });

        modelBuilder.Entity<Ristorante>(entity =>
        {
            entity.HasKey(ristorante => ristorante.Id);
            entity.Property(ristorante => ristorante.RagioneSociale).HasMaxLength(100).IsRequired();
            entity.Property(ristorante => ristorante.PartitaIva).HasMaxLength(13).IsRequired();
            entity.Property(ristorante => ristorante.Indirizzo).HasMaxLength(100).IsRequired();
            entity.Property(ristorante => ristorante.Citta).HasMaxLength(50);
            entity.Property(ristorante => ristorante.Telefono).HasMaxLength(20);
            entity.Property(ristorante => ristorante.PrezzoMedio).HasPrecision(10, 2);
            entity.Property(ristorante => ristorante.UsernameProprietario).HasMaxLength(20);

            entity.HasOne<Utente>()
                .WithMany()
                .HasForeignKey(r => r.UsernameProprietario)
                .HasPrincipalKey(u => u.UserName);
        });

        modelBuilder.Entity<Prenotazione>(entity =>
        {
            entity.HasKey(prenotazione => prenotazione.Id);
            entity.Property(prenotazione => prenotazione.NomeUtente).HasMaxLength(20).IsRequired();
        });

        modelBuilder.Entity<Tipologia>(entity =>
        {
            entity.HasKey(tipologia => tipologia.Id);
            entity.Property(tipologia => tipologia.Descrizione).HasMaxLength(50).IsRequired();
        });
    }
}
