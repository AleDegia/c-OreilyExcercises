using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLL;
using Models;
using ProgettoGestioneRistoranti;

namespace UI
{
    public partial class FormPrenotazione : Form
    {
        private Ristorante ristorante;
        private DatiPrenotazioneSubmit datiPrenotazioneSubmit;
        private BlPrenotazioni blPrenotazioni;
        private List<Prenotazione> prenotazioni;
        private int postiPerGiorno;
        private int giornoSelezionato;

        System.Windows.Forms.Label postiOgniGiorno;

        //dizionario dei posti prenotati in relazione alla data
        Dictionary<DateTime, int > dateEposti = new Dictionary< DateTime, int>();

        public FormPrenotazione(Ristorante ristorante)
        {
            InitializeComponent();
            this.ristorante = ristorante;
            datiPrenotazioneSubmit = new DatiPrenotazioneSubmit(ristorante, this);
            prenotazioni = new List<Prenotazione>();
            blPrenotazioni = new BlPrenotazioni();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            postiOgniGiorno = this.GetPostiDisponibili(); 
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Prenotazione_Load(object sender, EventArgs e)
        {
            label6.Text = ristorante.GetNumPosti().ToString();
            prenotazioni = blPrenotazioni.GetAllPrenotazioni(ristorante.GetIDRistorante());
            //Aggiungo ogni coppia di dataPrenotazione e numPersonePrenotate al dizionario
            foreach (var p in prenotazioni)
            {
                if (dateEposti.ContainsKey(p.DataPrenotazione.Date))
                {
                    // Se la data esiste, somma il numero di persone
                    dateEposti[p.DataPrenotazione.Date] += p.NumPersone;
                }
                else
                    dateEposti.Add(p.DataPrenotazione.Date, p.NumPersone);
            }


            //recupero data selezionata da utente
            DateTime dataSelezionata = monthCalendar1.SelectionStart;
            foreach(var entry in dateEposti)
            {
                //MessageBox.Show("Data: " + entry.Key.ToString("dd/MM/yyyy") + ", Posti: " + entry.Value.ToString());
            }
            //MessageBox.Show("Data selezionata: " + monthCalendar1.SelectionStart.Date.ToString("dd/MM/yyyy"));
            label4.Text = dateEposti[monthCalendar1.SelectionStart.Date].ToString();
            int postiDisp = Convert.ToInt32(label6.Text) - Convert.ToInt32(dateEposti[monthCalendar1.SelectionStart.Date]);
            label5.Text = postiDisp.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            datiPrenotazioneSubmit.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           
        }
    }
}
