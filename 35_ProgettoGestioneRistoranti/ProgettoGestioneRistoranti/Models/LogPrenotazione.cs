using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LogPrenotazione
    {
        private int _idLog { get; set; }
        private int _idPrenotazione { get; set; }   //chiave secondaria -> fa riferimento a chiave primaria di un altra tabella
        private DateTime _dataEvento { get; set; }
        private string _tipoEvento { get; set; }    //tipo di query fatta su Prenotazione
        private string _descrizioneEvento { get; set; }
        //nomeUtente c'è gia in Prenotazione

        // Costruttore per LogPrenotazione
        public LogPrenotazione(int idPrenotazione, DateTime dataEvento, string tipoEvento, string descrizioneEvento, int idRistorante)
        {
            _idPrenotazione = idPrenotazione;
            _dataEvento = dataEvento;
            _tipoEvento = tipoEvento;
            _descrizioneEvento = descrizioneEvento;
        }

        // Getter e Setter per IDLog
        public int IDLog
        {
            get { return _idLog; }
            set { _idLog = value; }
        }

        // Getter e Setter per IDPrenotazione
        public int IDPrenotazione
        {
            get { return _idPrenotazione; }
            set { _idPrenotazione = value; }
        }

        // Getter e Setter per DataEvento
        public DateTime DataEvento
        {
            get { return _dataEvento; }
            set { _dataEvento = value; }
        }

        // Getter e Setter per TipoEvento
        public string TipoEvento
        {
            get { return _tipoEvento; }
            set { _tipoEvento = value; }
        }

        // Getter e Setter per DescrizioneEvento
        public string DescrizioneEvento
        {
            get { return _descrizioneEvento; }
            set { _descrizioneEvento = value; }
        }


    }
}
