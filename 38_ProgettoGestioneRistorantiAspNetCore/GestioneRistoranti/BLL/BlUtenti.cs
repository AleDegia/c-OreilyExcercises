using DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;

namespace BLLL
{
    public class BlUtenti
    {
        private GestioneRistorantiContext context;
        public BlUtenti()
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: false)
             .Build();

            var connectionString = configuration.GetConnectionString(
            "GestioneRistorantiConnectionString"
        );

            var options = new DbContextOptionsBuilder<GestioneRistorantiContext>()
                .UseSqlServer(connectionString)
                .Options;

            context = new GestioneRistorantiContext(options);
        }

        public Utente GetUtente(string username)
        {
            return context.Utenti.Find(username);
        }

        public List<Utente> GetUtenti()
        {
            List<Utente> utenti = context.Utenti.ToList(); ;
            return utenti;
        }
        public void AggiungiUtente(Utente utente)
        {
            context.Add(utente);
            context.SaveChanges();
        }

        public void ModificaUtente(Utente utente)
        {
            context.Update(utente);
            context.SaveChanges();
        }

        public void CancellaUtente(Utente utente)
        {
            var utenteDaCancellare = context.Utenti.Find(utente.UserName);
            context.Remove(utenteDaCancellare);
            context.SaveChanges();
        }
    }
}
