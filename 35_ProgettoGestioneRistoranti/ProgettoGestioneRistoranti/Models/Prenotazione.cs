using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Models
{
    public class Prenotazione
    {
        private int _idPrenotazione { get; set; }
        private int _idRistorante { get; set; }
        private string _nomeUtente { get; set; }
        private DateTime _dataRichiesta { get; set; }
        private DateTime _dataPrenotazione { get; set; }   
        private int _numPersone { get; set; }

        public Prenotazione(int iDPrenotazione, int iDRistorante, string nomeUtente, DateTime dataRichiesta, DateTime dataPrenotazione, int numPersone)
        {
            _idPrenotazione = iDPrenotazione;
            _idRistorante = iDRistorante;
            _nomeUtente = nomeUtente;
            _dataRichiesta = dataRichiesta;
            _dataPrenotazione = dataPrenotazione;
            _numPersone = numPersone;
        }

        // Costruttore senza IdPrenotazione per fare l'insert dato che c'è IDPrenotazione IDENTITY
        public Prenotazione(int iDRistorante, string nomeUtente, DateTime dataRichiesta, DateTime dataPrenotazione, int numPersone)
        {
            _idRistorante = iDRistorante;
            _nomeUtente = nomeUtente;
            _dataRichiesta = dataRichiesta;
            _dataPrenotazione = dataPrenotazione;
            _numPersone = numPersone;
        }

        // Getter e Setter per IDPrenotazione
        public int IDPrenotazione
        {
            get { return _idPrenotazione; }
            set { _idPrenotazione = value; }
        }

        // Getter e Setter per IDRistorante
        public int IDRistorante
        {
            get { return _idRistorante; }
            set { _idRistorante = value; }
        }

        // Getter e Setter per NomeUtente
        public string NomeUtente
        {
            get { return _nomeUtente; }
            set { _nomeUtente = value; }
        }

        // Getter e Setter per DataRichiesta
        public DateTime DataRichiesta
        {
            get { return _dataRichiesta; }
            set { _dataRichiesta = value; }
        }

        // Getter e Setter per DataPrenotazione
        public DateTime DataPrenotazione
        {
            get { return _dataPrenotazione; }
            set { _dataPrenotazione = value; }
        }

        // Getter e Setter per NumPersone
        public int NumPersone
        {
            get { return _numPersone; }
            set { _numPersone = value; }
        }
    }
}
