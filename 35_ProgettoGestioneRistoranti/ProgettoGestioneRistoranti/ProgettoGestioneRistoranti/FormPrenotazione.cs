using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLL;
using Models;
using ProgettoGestioneRistoranti;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    public partial class FormPrenotazione : Form
    {
        private Ristorante ristorante;
        private DatiPrenotazioneSubmit datiPrenotazioneSubmit;
        private BlPrenotazioni blPrenotazioni;
        private BlUtenti blUtenti;
        private List<Prenotazione> prenotazioni;
        private List<Prenotazione> prenotazioniXdata;
        private List<int> ids;
        private List<Utente> utenti;
        private int postiPerGiorno;
        private int giornoSelezionato;
        private DateTime dataSelezionata;
        private DateTime inizioRangeSelezione = new DateTime(2001, 2, 13);
        DateTime fineRangeSelezione = new DateTime(2001, 2, 28);
        private string username;


        System.Windows.Forms.Label postiOgniGiorno;

        //dizionario dei posti prenotati in relazione alla data
        Dictionary<DateTime, int > dateEposti = new Dictionary< DateTime, int>();
        List<DateTime> rangeDiDate = new List<DateTime>();

        public FormPrenotazione(Ristorante ristorante, string username)
        {
            InitializeComponent();
            this.ristorante = ristorante;
            //datiPrenotazioneSubmit = new DatiPrenotazioneSubmit(ristorante, this, dataSelezionata);
            prenotazioni = new List<Prenotazione>();
            utenti = new List<Utente>();
            blPrenotazioni = new BlPrenotazioni();
            blUtenti = new BlUtenti();
            ids = new List<int>();
            this.username = username;
        }

        private void CaricaPrenotazioni()
        {
            label6.Text = ristorante.GetNumPosti().ToString();
            prenotazioni = blPrenotazioni.GetAllPrenotazioni(ristorante.GetIDRistorante()); //recupero prenotazioni di quel ristorante da db
            dateTimePicker1.Value = monthCalendar1.SelectionStart.Date;
            textBoxIdRist.Text = ristorante.GetIDRistorante().ToString();

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

            //popolo griglia utenti prenotati nel giorno/giorni selezionati (devo prendere dalle prenotazioni del giorno selezionato
            //gli id degli utenti dagli oggetti prenotazione recuperati)
            //recupero data selezionata da utente
            dataSelezionata = monthCalendar1.SelectionStart;
            prenotazioniXdata = blPrenotazioni.GetPrenotazioniPerData(dataSelezionata);
            UtentiPrenotati.Items.Clear();
            foreach (Prenotazione prenotazione in prenotazioniXdata)
            {
                string nomeUtente = prenotazione.NomeUtente;   //fare lista di id
                utenti.Add(blUtenti.GetUtente(nomeUtente));
                UtentiPrenotati.Items.Add(nomeUtente);
            }


            try
            {
                label4.Text = dateEposti[monthCalendar1.SelectionStart.Date].ToString();
                int postiDisp = Convert.ToInt32(label6.Text) - Convert.ToInt32(dateEposti[monthCalendar1.SelectionStart.Date]);
                label5.Text = postiDisp.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Non ci sono prenotazioni per questo ristorante");
                label6.Text = ristorante.GetNumPosti().ToString();
                label4.Text = "0";
                label5.Text = ristorante.GetNumPosti().ToString();
            }
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
            textBox1.Text = username;
            dateTimePicker1.Value = monthCalendar1.SelectionStart.Date;
            textBoxIdRist.Text = ristorante.GetIDRistorante().ToString();

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

            //popolo griglia utenti prenotati nel giorno/giorni selezionati (devo prendere dalle prenotazioni del giorno selezionato
            //gli id degli utenti dagli oggetti prenotazione recuperati)
            //recupero data selezionata da utente
            dataSelezionata = monthCalendar1.SelectionStart;
            prenotazioniXdata = blPrenotazioni.GetPrenotazioniPerData(dataSelezionata);
            foreach (Prenotazione prenotazione in prenotazioniXdata)
            {
                if (ristorante.GetIDRistorante() == prenotazione.IDRistorante)
                {
                    string nomeUtente = prenotazione.NomeUtente;   //fare lista di id
                    utenti.Add(blUtenti.GetUtente(nomeUtente));
                    UtentiPrenotati.Items.Add(nomeUtente);
                }
            }


            try
            {
                label4.Text = dateEposti[monthCalendar1.SelectionStart.Date].ToString();
                int postiDisp = Convert.ToInt32(label6.Text) - Convert.ToInt32(dateEposti[monthCalendar1.SelectionStart.Date]);
                label5.Text = postiDisp.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Non ci sono prenotazioni per questo ristorante");
                label6.Text = ristorante.GetNumPosti().ToString();
                label4.Text= "0";
                label5.Text = ristorante.GetNumPosti().ToString();
            }
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
            dateTimePicker1.Value = monthCalendar1.SelectionStart.Date;

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

                HashSet<Prenotazione> prenotazioniUniche = new HashSet<Prenotazione>(); //per avere prenotazioni uniche

                foreach (DateTime data in rangeDiDate)
                {
                    List<Prenotazione> prenotazioniTemp = blPrenotazioni.GetPrenotazioniPerData(data);

                    // Aggiungo ogni prenotazione solo se non è già presente
                    foreach (var prenotazione in prenotazioniTemp)
                    {
                        prenotazioniUniche.Add(prenotazione);
                    }
                }

                // Aggiungo tutte le prenotazioni uniche alla lista
                prenotazioniXdata = prenotazioniUniche.ToList();

                UtentiPrenotati.Items.Clear();
                foreach (Prenotazione prenotazione in prenotazioniXdata)
                {
                    string username = prenotazione.NomeUtente;
                    utenti.Add(blUtenti.GetUtente(username));
                    UtentiPrenotati.Items.Add(username);
                }

                try
                {
                    label4.Text = sommaPrenotazioni.ToString();
                    return;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("non ci sono prenotazioni per la data selezionata");
                    label5.Text = label6.Text;
                    label4.Text = "0";
                }
            }

            //caricamento utenti
            dataSelezionata = monthCalendar1.SelectionStart;
            prenotazioniXdata = blPrenotazioni.GetPrenotazioniPerData(dataSelezionata);
            
            UtentiPrenotati.Items.Clear();
            foreach (Prenotazione prenotazione in prenotazioniXdata)
            {
                if (ristorante.GetIDRistorante() == prenotazione.IDRistorante)
                {
                    string username = prenotazione.NomeUtente;   //fare lista di id
                    utenti.Add(blUtenti.GetUtente(username));
                    UtentiPrenotati.Items.Add(username);
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
           
            try
            { 
                label4.Text = dateEposti[monthCalendar1.SelectionStart.Date].ToString();
                int postiDisp = Convert.ToInt32(label6.Text) - Convert.ToInt32(dateEposti[monthCalendar1.SelectionStart.Date]);
                label5.Text = postiDisp.ToString();
            }
            catch(Exception ex)
            {
                //MessageBox.Show("non ci sono prenotazioni per la data selezionata");
                label5.Text = label6.Text;
                label4.Text = "0";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Imposta il raggio per l'arrotondamento degli angoli
            int borderRadius = 20;

            // Usa SmoothingMode per ottenere bordi lisci
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            panel2.BorderStyle = BorderStyle.None;

            // Crea un pennello per il colore di sfondo
            using (Brush brush = new SolidBrush(panel2.BackColor))
            {
                // Disegna il riempimento del pannello (con il colore di sfondo)
                e.Graphics.FillRectangle(brush, new Rectangle(0, 0, panel2.Width, panel2.Height));
            }

            // Crea un pennello per il bordo
            using (Pen pen = new Pen(Color.Gray))  // Puoi cambiare il colore del bordo
            {
                // Disegna gli angoli arrotondati in alto a sinistra e a destra
                e.Graphics.DrawArc(pen, 0, 0, borderRadius * 2, borderRadius * 2, 180, 90);  // Angolo in alto a sinistra
                e.Graphics.DrawArc(pen, panel2.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);  // Angolo in alto a destra

                // Disegna le linee rette del bordo
                // Lato superiore (da sinistra a destra, tra gli angoli arrotondati)
                e.Graphics.DrawLine(pen, borderRadius, 0, panel2.Width - borderRadius, 0);

                // Lato sinistro (da alto a basso)
                e.Graphics.DrawLine(pen, 0, borderRadius, 0, panel2.Height);

                // Lato destro (da alto a basso)
                e.Graphics.DrawLine(pen, panel2.Width, borderRadius, panel2.Width, panel2.Height);

                // Lato inferiore (da sinistra a destra, tra gli angoli arrotondati)
                e.Graphics.DrawLine(pen, borderRadius, panel2.Height, panel2.Width - borderRadius, panel2.Height);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
            DateTime dataSelezionata = monthCalendar1.SelectionStart;
            int idRistorante = Convert.ToInt32(textBoxIdRist.Text);
            string username = textBox1.Text;
            DateTime dataEOraCorrente = DateTime.Now.Date;
            int numeroPersone = Convert.ToInt32(textBox4.Text);

            Prenotazione prenotazione = new Prenotazione(idRistorante, username, dataEOraCorrente, dataSelezionata, numeroPersone);
            
                blPrenotazioni.AggiungiPrenotazione(prenotazione);
               MessageBox.Show("Prenotazione avvenuta con successo per il giorno " + dataSelezionata.Day);
                CaricaPrenotazioni();
            }
            catch (Exception ex)
            {
                MessageBox.Show("la prenotazione non è andata a buon fine");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            // Cambia il colore di sfondo del bottone quando viene cliccato
        

    }

        private void UtentiPrenotati_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
