using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Prenotazione
    {
        private int IDPrenotazione { get; set; }
        private int IDRistorante { get; set; }
        private string NomeUtente { get; set; }
        private DateTime DataRichiesta { get; set; }
        private DateTime DataPrenotazione { get; set; }
        private int NumPersone { get; set; }

        public Prenotazione(int iDPrenotazione, int iDRistorante, string nomeUtente, DateTime dataRichiesta, DateTime dataPrenotazione, int numPersone)
        {
            IDPrenotazione = iDPrenotazione;
            IDRistorante = iDRistorante;
            NomeUtente = nomeUtente;
            DataRichiesta = dataRichiesta;
            DataPrenotazione = dataPrenotazione;
            NumPersone = numPersone;
        }
    }
}
