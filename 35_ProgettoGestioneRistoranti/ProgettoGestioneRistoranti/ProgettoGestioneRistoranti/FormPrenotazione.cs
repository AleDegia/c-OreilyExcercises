using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
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
        private DateTime dataSelezionata;
        private DateTime inizioRangeSelezione = new DateTime(2001, 2, 13);
        DateTime fineRangeSelezione = new DateTime(2001, 2, 28);

        System.Windows.Forms.Label postiOgniGiorno;

        //dizionario dei posti prenotati in relazione alla data
        Dictionary<DateTime, int > dateEposti = new Dictionary< DateTime, int>();
        List<DateTime> rangeDiDate = new List<DateTime>();

        public FormPrenotazione(Ristorante ristorante)
        {
            InitializeComponent();
            this.ristorante = ristorante;
            //datiPrenotazioneSubmit = new DatiPrenotazioneSubmit(ristorante, this, dataSelezionata);
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
            prenotazioni = blPrenotazioni.GetAllPrenotazioni(ristorante.GetIDRistorante()); //recupero prenotazioni di quel ristorante da db
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
            dataSelezionata = monthCalendar1.SelectionStart;
            
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
            datiPrenotazioneSubmit = new DatiPrenotazioneSubmit(ristorante, this, dataSelezionata);
            datiPrenotazioneSubmit.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            prenotazioni.Clear();
            prenotazioni = blPrenotazioni.GetAllPrenotazioni(ristorante.GetIDRistorante());
            dateEposti.Clear();

            inizioRangeSelezione = monthCalendar1.SelectionStart.Date;
            fineRangeSelezione = monthCalendar1.SelectionEnd.Date;

            //vedo se è stato selezionato un range di date
            if (inizioRangeSelezione<fineRangeSelezione)
            {
                dateEposti.Clear();
                monthCalendar1.SelectionRange = new SelectionRange(inizioRangeSelezione, fineRangeSelezione);
                rangeDiDate = Enumerable.Range(0, (int)(fineRangeSelezione - inizioRangeSelezione).TotalDays + 1)
                      .Select(x => inizioRangeSelezione.AddDays(x))
                      .ToList();
                int sommaPrenotazioni = 0;
                //per ogni prenotazine che ho nel db
                foreach (var p in prenotazioni)
                {
                    //per ogni data selezionata
                    foreach (DateTime data in rangeDiDate)
                    {
                        //vedo se la prenotazione è per quella data, e se si aggiungo alla somma totale il numPersone prenotate
                        if (p.DataPrenotazione.Date == data.Date)
                        {
                            sommaPrenotazioni += p.NumPersone;
                        }
                    }
                }

                try{
                    label4.Text = sommaPrenotazioni.ToString();
                    return;
                    //int postiDisp = Convert.ToInt32(label6.Text) - Convert.ToInt32(dateEposti[monthCalendar1.SelectionStart.Date]);
                   // label5.Text = postiDisp.ToString();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("non ci sono prenotazioni per la data selezionata");
                    label5.Text = "50";
                    label4.Text = "0";
                }
            }


            foreach (var p in prenotazioni)
            {
                if (dateEposti.ContainsKey(p.DataPrenotazione.Date))
                {
                    dateEposti[p.DataPrenotazione.Date] += p.NumPersone;
                }
                else
                    dateEposti.Add(p.DataPrenotazione.Date, p.NumPersone);
            }
            //recupero data selezionata da utente
            dataSelezionata = monthCalendar1.SelectionStart;
            MessageBox.Show(dataSelezionata.ToString());
           
            try
            { 
                label4.Text = dateEposti[monthCalendar1.SelectionStart.Date].ToString();
                int postiDisp = Convert.ToInt32(label6.Text) - Convert.ToInt32(dateEposti[monthCalendar1.SelectionStart.Date]);
                label5.Text = postiDisp.ToString();
            }
            catch(Exception ex)
            {
                //MessageBox.Show("non ci sono prenotazioni per la data selezionata");
                label5.Text = "50";
                label4.Text = "0";
            }
        }
    }
}
