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
    }
}
