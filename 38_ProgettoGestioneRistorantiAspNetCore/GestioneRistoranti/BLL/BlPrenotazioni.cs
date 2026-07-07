using BLL;
using DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLLL
{
    public class BlPrenotazioni
    {
        private GestioneRistorantiContext context;

        //public BlPrenotazioni(GestioneRistorantiContext context)
        //{
        //    this.context = context;
        //}
        public BlPrenotazioni()
        {
            IConfiguration configuration = Utility.ServiceProvider.GetRequiredService<IConfiguration>();
            context = Utility.ServiceProvider.GetRequiredService<GestioneRistorantiContext>();
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
            return context.Prenotazioni
                     .Where(p => p.DataPrenotazione.Date == data.Date)
                     .ToList();
        }

        public Prenotazione GetPrenotazionePerNome(string username)
        {
            return context.Prenotazioni.FirstOrDefault(p => p.NomeUtente == username);
        }

        public List<Prenotazione> GetPrenotazioni()
        {
            List<Prenotazione> prenotazioni = context.Prenotazioni.ToList(); 
            return prenotazioni;
        }

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

        public void CancellaPrenotazioni(string username)
        {
           // dal.CancellaPrenotazione(username);
           context.Prenotazioni.RemoveRange(context.Prenotazioni.Where(p => p.NomeUtente == username));
           context.SaveChanges();
        }
        public void CancellaPrenotazione(int id)
        {
            // dal.CancellaPrenotazione(username);
            context.Prenotazioni.RemoveRange(context.Prenotazioni.Where(p => p.IDPrenotazione == id));
            context.SaveChanges();
        }

    }
}
