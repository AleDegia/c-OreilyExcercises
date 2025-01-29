using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using System.Windows.Forms;
using Models;
using DALe;

namespace BLLL
{
    public class BlPrenotazioni
    {
        private DalPrenotazioni dal;
        public BlPrenotazioni()
        {
            dal = new DalPrenotazioni();
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
    }
}
