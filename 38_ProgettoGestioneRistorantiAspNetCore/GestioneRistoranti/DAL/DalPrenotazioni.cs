using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DALe
{
    public class DalPrenotazioni
    {
        private readonly GestioneRistorantiContext context;
        public DalPrenotazioni() 
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

        public List<Prenotazione> GetAllPrenotazioni()
        {
            return context.Prenotazioni.ToList();
        }

        public void AggiungiPrenotazione(Prenotazione prenotazione)
        {
            context.Prenotazioni.Add(prenotazione);
            context.SaveChanges();
        }



        public List<Prenotazione> GetAllPrenotazioniRistorante(int idRistorante)
        {
            return context.Prenotazioni
                      .Where(p => p.IDRistorante == idRistorante)
                      .ToList();
        }


        public List<Prenotazione> GetPrenotazioniPerData(DateTime data)
        {
            //string query = "SELECT * FROM Prenotazioni WHERE DataPrenotazione = @DataPrenotazione";
            return context.Prenotazioni
                     .Where(p => p.DataPrenotazione.Date == data.Date)
                     .ToList();
        }


        //public List<Prenotazione> GetPrenotazioni()
        //{
        //    List<object> entities = dbData.GetAllEntities();
        //    List<Prenotazione> prenotazioni = entities.OfType<Prenotazione>().ToList();
        //    return prenotazioni;
        //}

        public void AggiornaPrenotazioneELog(Prenotazione prenotazione)
        {
            try
            {
                var prenotazioneDb = context.Prenotazioni
                    .FirstOrDefault(p => p.IDPrenotazione == prenotazione.IDPrenotazione);

                if (prenotazioneDb == null)
                    throw new Exception("Prenotazione non trovata");

                prenotazioneDb.IDRistorante = prenotazione.IDRistorante;
                prenotazioneDb.NomeUtente = prenotazione.NomeUtente;
                prenotazioneDb.DataRichiesta = prenotazione.DataRichiesta;
                prenotazioneDb.DataPrenotazione = prenotazione.DataPrenotazione;
                prenotazioneDb.NumPersone = prenotazione.NumPersone;

                var log = new LogPrenotazione
                {
                    IDPrenotazione = prenotazione.IDPrenotazione,
                    DataEvento = DateTime.Now,
                    TipoEvento = "Modifica",
                    DescrizioneEvento = $"Modifica prenotazione per l'utente {prenotazione.NomeUtente}"
                };

                context.LogPrenotazioni.Add(log);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante aggiornamento prenotazione e inserimento log", ex);
            }
        }

        public Prenotazione? GetPrenotazione(string username)
        {
            //string query = "SELECT TOP 1 * FROM Prenotazioni WHERE NomeUtente = @userName";
            return context.Prenotazioni.FirstOrDefault(p => p.NomeUtente == username);
        }


        public void CancellaPrenotazione(string username)
        {
            //dbData.CancellaEntity(username, "Prenotazioni");
        }
    }
}
