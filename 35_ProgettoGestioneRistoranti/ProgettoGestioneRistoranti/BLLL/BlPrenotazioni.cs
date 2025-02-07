using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using System.Windows.Forms;
using Models;
using DALe;
using System.Xml.Linq;

namespace BLLL
{
    public class BlPrenotazioni
    {
        private DalPrenotazioni dal;
        public BlPrenotazioni()
        {
            dal = new DalPrenotazioni();
        }

        public List<Prenotazione> GetAllPrenotazioni()
        {
            return dal.GetAllPrenotazioni();
        }

        public void AggiungiPrenotazione(Prenotazione prenotazione)
        {
            dal.AggiungiPrenotazione(prenotazione);
        }

        public List<Prenotazione> GetAllPrenotazioni(int idRistorante)
        {
            List<Prenotazione> prenotazioni = dal.GetAllPrenotazioni(idRistorante);
            return prenotazioni;
        }

        public List<Prenotazione> GetPrenotazioniPerData(DateTime data)
        {
            List<Prenotazione> prenotazioni = dal.GetPrenotazioniPerData(data);
            return prenotazioni;
        }

        public Prenotazione GetPrenotazionePerNome(string username)
        {
            Prenotazione pren = dal.GetPrenotazione(username);
            return pren;
        }

        public List<Prenotazione> GetPrenotazioni()
        {
            List<Prenotazione> prenotazioni = dal.GetPrenotazioni();
            return prenotazioni;
        }

        public void AggiornaPrenotazioneELog(Prenotazione prenotazione)
        {
            try
            {
                dal.AggiornaPrenotazioneELog(prenotazione);
            }
            catch (Exception ex)
            {
                throw;  // Rilancio l'eccezione mantenendo la stack trace
            }
        }

        public void CancellaPrenotazione(string username)
        {
            dal.CancellaPrenotazione(username);
        }
    }
}
