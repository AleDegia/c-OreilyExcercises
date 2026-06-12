using DALe;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    public class DalUtenti
    {
        private readonly GestioneRistorantiContext context;

      

        public DalUtenti()
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
            //per prendere la propagazione dell'errore da dbData
            try
            {
                return context.Utenti.Find(username);
            }
            catch (Exception ex)
            {
                // Loggare o gestire l'errore, ad esempio:
                Console.WriteLine("Errore durante il recupero dell'utente: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public List<Utente> GetUtenti()
        {
            try
            {
                // Ottengo la lista generica 
                List<Utente> utenti = context.Utenti.ToList(); ;
                return utenti;
            }
            catch (Exception ex)
            {
                // Loggare o gestire l'errore, ad esempio:
                Console.WriteLine("Errore durante il recupero degli utenti: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public void AggiungiUtente(Utente utente)
        {
            try
            {
                context.Add(utente);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Loggare o gestire l'errore, ad esempio:
                Console.WriteLine("Errore durante l'inserimento dell'utente: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public void ModificaUtente(Utente utente)
        { 
            context.Update(utente);
            context.SaveChanges();
        }

        public void CancellaUtente(Utente utente)
        {
            context.Remove(utente);
            context.SaveChanges();
        }


    }
}
