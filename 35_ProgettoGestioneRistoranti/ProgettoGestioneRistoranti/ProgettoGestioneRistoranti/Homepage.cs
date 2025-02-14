using BLLL;
using Engine;
using Models;
using ProgettoGestioneRistoranti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class Homepage : Form
    {
        private ElencoRistoranti elencoRistoranti;
        private ElencoUtenti elencoUtenti;
        private ElencoPrenotazioni elencoPrenotazioni;
        private BlPrenotazioni blPrenotazioni;
        private BlRistoranti blRistoranti;
        private string username;
        private List<Ristorante> ristoranti;
        private Ristorante ristorante;
        public Homepage(string username)
        {
            InitializeComponent();
            elencoRistoranti = new ElencoRistoranti(username);
            elencoPrenotazioni = new ElencoPrenotazioni();
            this.username = username;
            blPrenotazioni = new BlPrenotazioni();
            blRistoranti = new BlRistoranti();
            ristoranti = new List<Ristorante>();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        //devo per ogni ristorante prendere ogni prenotazione e calcolarne il guadagno (num posti della prenotazione * prezzo medio ristorante)
        private void Form1_Load(object sender, EventArgs e)
        {
            //riempio comboBox coi ristoranti
            ristoranti = blRistoranti.GetRistorantiFiltrati();
            foreach (Ristorante rist in ristoranti)
            {
               comboBox1.Items.Add(rist.GetRagioneSociale());
            }
            //chart3.Series.Add("Ricavi");
            chart3.ChartAreas[0].AxisX.LabelStyle.Angle = 45;  // Ruota le etichette per evitare sovrapposizioni
            chart3.ChartAreas[0].AxisX.Interval = 1;

            //recupero tutte le prenotazioni per ogni ristorante e ne calcolo i guadagni per mese col prezzo medio del ristorante
            List<Prenotazione> prenotazioni = blPrenotazioni.GetAllPrenotazioni();
            // Dizionario per tenere traccia dei guadagni per ogni mese
            Dictionary<string, decimal> guadagniPerMese = new Dictionary<string, decimal>();

            guadagniPerMese = blRistoranti.GetGuadagniPerMese2024();

            // Aggiungi i punti dati al grafico
            foreach (var mese in guadagniPerMese)
            {
                chart1.Series["Ricavi"].Points.AddXY(mese.Key, mese.Value);
            }

            // Configura l'asse X per visualizzare tutte le etichette
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;  // Ruota le etichette per evitare sovrapposizioni
            chart1.ChartAreas[0].AxisX.Interval = 1;  // Imposta un intervallo di 1 per visualizzare tutte le etichette


            // Filtra le prenotazioni per l'anno 2024
            var prenotazioni2024 = prenotazioni.Where(p => p.DataPrenotazione.Year == 2024).ToList();
            int numPrenotazioni1 = 0;
            int numPrenotazioni2 = 0;
            int numPrenotazioni3 = 0;
            int numPrenotazioni4 = 0;
            foreach (var prenotazione in prenotazioni2024)
            {
                switch(prenotazione.DataPrenotazione.Month)
                {
                    case 01:
                    case 02:
                    case 03:
                        numPrenotazioni1++;
                        break;
                    case 04:
                    case 05:
                    case 06:
                        numPrenotazioni2++;
                        break;
                    case 07:
                    case 08:
                    case 09:
                        numPrenotazioni3++;
                        break;
                    case 10:
                    case 11:
                    case 12:
                        numPrenotazioni4++;
                        break;
                }
            }

            // Assicurati che la serie "Serie1" esista
            chart2.Series.Add("Serie1");
            chart2.Series["Serie1"].Points.Clear(); 

            chart2.Series["Serie1"].Points.AddXY("Trimstre 1", (float)prenotazioni2024.Count/numPrenotazioni1);  
            chart2.Series["Serie1"].Points.AddXY("Trimestre 2", (float)prenotazioni2024.Count / numPrenotazioni2);  
            chart2.Series["Serie1"].Points.AddXY("Trimestre 3", (float)prenotazioni2024.Count / numPrenotazioni3);  
            chart2.Series["Serie1"].Points.AddXY("Trimestre 4", (float)prenotazioni2024.Count / numPrenotazioni4);  

            chart2.Series["Serie1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie; // Imposta il tipo di grafico come torta
            chart2.Series["Serie1"].IsValueShownAsLabel = true; // Mostra il valore su ogni segmento
            chart2.Series["Serie1"].Label = "#PERCENT"; // Mostra la percentuale sul grafico
            chart2.Series["Serie1"].BorderWidth = 2; 

        }



        private void button1_Click(object sender, EventArgs e)
        {
            elencoPrenotazioni.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            elencoRistoranti.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (elencoUtenti == null)
            {
                elencoUtenti = new ElencoUtenti();
            }
            elencoUtenti.Show();
            elencoUtenti.Activate();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {
        }

        //quando seleziono un ristorante devo cambiare i dati del grafico con i guadagni del 2024 di quel ristorante
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ristorante = ristoranti.FirstOrDefault(r => r.GetRagioneSociale() == comboBox1.SelectedItem.ToString());
            
            Dictionary<string, decimal> guadagniPerMeseRistorante = new Dictionary<string, decimal>();
            guadagniPerMeseRistorante = blRistoranti.GetGuadagniPerMeseRistorante(ristorante.GetIDRistorante());

            // Aggiungi i punti dati al grafico
            chart3.Series["Ricavi"].Points.Clear();
            foreach (var mese in guadagniPerMeseRistorante)
            {
                chart3.Series["Ricavi"].Points.AddXY(mese.Key, mese.Value);
            }

        }

        private void chart3_Click(object sender, EventArgs e)
        {
        }
    }
}
