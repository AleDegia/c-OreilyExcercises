using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ristorante : AbstractClass
    {
        private int IDRistorante { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Tipologia deve essere compreso tra 1 e 5.")]
        private int Tipologia { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "L'indirizzo non può superare i 100 caratteri.")]
        private string Indirizzo { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "La Ragione Sociale non può superare i 100 caratteri.")]
        private string RagioneSociale { get; set; }
        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression(@"^IT", ErrorMessage = "La Partita IVA deve iniziare con 'IT'.")]
        private string PartitaIva { get; set; }
        [Required]
        private int NumPosti { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]   //max 2 numeri decimali
        private decimal PrezzoMedio {  get; set; }

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
