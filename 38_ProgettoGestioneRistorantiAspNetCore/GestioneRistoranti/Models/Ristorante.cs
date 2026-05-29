using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("AnagraficaRistoranti")] //nome della tabella nel database
    public class Ristorante : AbstractClass
    {
        private int _idRistorante { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Tipologia deve essere compreso tra 1 e 5.")]
        public int Tipologia { get; set; }     //riferimento a tabella tipologia
        [Required]
        [StringLength(100, ErrorMessage = "L'indirizzo non può superare i 100 caratteri.")]
        public string Indirizzo { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "La Ragione Sociale non può superare i 100 caratteri.")]
        public string RagioneSociale { get; set; }
        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression(@"^IT", ErrorMessage = "La Partita IVA deve iniziare con 'IT'.")]
        public string PartitaIva { get; set; }
        [Required]
        public int NumPosti { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]   //max 2 numeri decimali
        public decimal PrezzoMedio {  get; set; }

        public Ristorante(int idRistorante, int tipologia, string indirizzo, string ragioneSociale, string partitaIva, int numPosti, decimal prezzoMedio, string telefono, string citta) : base(telefono, citta)
        {
            IDRistorante = idRistorante;
            Tipologia = tipologia;
            Indirizzo = indirizzo;
            RagioneSociale = ragioneSociale;
            PartitaIva = partitaIva;
            NumPosti = numPosti;
            PrezzoMedio = prezzoMedio;
        }

        public Ristorante(string telefono, string citta) : base(telefono, citta)
        {

        }

        //private List<Prenotazione> Prenotazioni { get; set;}

        // Proprietà pubbliche per accedere ai campi privati
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRistorante
        {
            get { return _idRistorante; }
            set { _idRistorante = value; }
        }
        public int GetIDRistorante() => IDRistorante;
        public int GetTipologia() => Tipologia;
        public string GetIndirizzo() => Indirizzo;
        public string GetRagioneSociale() => RagioneSociale;
        public string GetPartitaIva() => PartitaIva;
        public int GetNumPosti() => NumPosti;
        public decimal GetPrezzoMedio() => PrezzoMedio;

        public void SetIDRistorante(int idRistorante) => IDRistorante = idRistorante;
        public void SetTipologia(int tipologia) => Tipologia = tipologia;
        public void SetIndirizzo(string indirizzo) => Indirizzo = indirizzo;
        public void SetRagioneSociale(string ragioneSociale) => RagioneSociale = ragioneSociale;
        public void SetPartitaIva(string partitaIva) => PartitaIva = partitaIva;
        public void SetNumPosti(int numPosti) => NumPosti = numPosti;
        public void SetPrezzoMedio(decimal prezzoMedio) => PrezzoMedio = prezzoMedio;

    }
}
