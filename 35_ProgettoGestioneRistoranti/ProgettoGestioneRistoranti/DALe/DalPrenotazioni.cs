using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Models;

namespace DALe
{
    public class DalPrenotazioni
    {
        private DbData<Prenotazione> dbData;
        public DalPrenotazioni() 
        {
            dbData = new DbData<Prenotazione>();
        }
        public void AggiungiPrenotazione(Prenotazione prenotazione)
        {
            dbData.AggiungiPrenotazione(prenotazione);
        }

        public List<Prenotazione> GetAllPrenotazioni(int idRistorante)
        {
            List<Prenotazione> prenotazioni = dbData.GetAllPrenotazioni(idRistorante);
            return prenotazioni;
        }

        public List<Prenotazione> GetPrenotazioniPerData(DateTime data)
        {
            List<Prenotazione> prenotazioni = dbData.GetPrenotazioniPerData(data);
            return prenotazioni;
        }

        public List<Prenotazione> GetPrenotazioni()
        {
            List<object> entities = dbData.GetAllEntities();
            List<Prenotazione> prenotazioni = entities.OfType<Prenotazione>().ToList();
            return prenotazioni;
        }

        public void AggiornaPrenotazioneELog(Prenotazione prenotazione)
        {
            try
            {
                dbData.AggiornaPrenotazioneELog(prenotazione);
            }
            catch (Exception ex)
            {
                throw; //rilancio eccezione
            }
        }
    }
}
