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

namespace UI
{
    public partial class Homepage : Form
    {
        private ElencoRistoranti elencoRistoranti;
        private ElencoUtenti elencoUtenti;
        private ElencoPrenotazioni elencoPrenotazioni;
        private string username;
        public Homepage(string username)
        {
            InitializeComponent();
            elencoRistoranti = new ElencoRistoranti(username);
            elencoPrenotazioni = new ElencoPrenotazioni();
            this.username = username;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Aggiungi i punti dati al grafico
            chart1.Series["Entrate"].Points.AddXY("Gennaio", 1000);
            chart1.Series["Entrate"].Points.AddXY("Febbraio", 1500);
            chart1.Series["Entrate"].Points.AddXY("Marzo", 700);
            chart1.Series["Entrate"].Points.AddXY("Aprile", 600);
            chart1.Series["Entrate"].Points.AddXY("Maggio", 930);
            chart1.Series["Entrate"].Points.AddXY("Giugno", 1300);
            chart1.Series["Entrate"].Points.AddXY("Luglio", 1000);
            chart1.Series["Entrate"].Points.AddXY("Agosto", 1000);
            chart1.Series["Entrate"].Points.AddXY("Settembre", 1000);
            chart1.Series["Entrate"].Points.AddXY("Ottobre", 1000);
            chart1.Series["Entrate"].Points.AddXY("Novembre", 1000);

            // Configura l'asse X per visualizzare tutte le etichette
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;  // Ruota le etichette per evitare sovrapposizioni
            chart1.ChartAreas[0].AxisX.Interval = 1;  // Imposta un intervallo di 1 per visualizzare tutte le etichette


            // Assicurati che la serie "Serie1" esista
            
                chart2.Series.Add("Serie1");
            

           
            chart2.Series["Serie1"].Points.Clear(); 

            
            chart2.Series["Serie1"].Points.AddXY("Categoria 1", 35);  
            chart2.Series["Serie1"].Points.AddXY("Categoria 2", 25);  
            chart2.Series["Serie1"].Points.AddXY("Categoria 3", 15);  
            chart2.Series["Serie1"].Points.AddXY("Categoria 4", 10);  
            chart2.Series["Serie1"].Points.AddXY("Categoria 5", 15);  

            chart2.Series["Serie1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie; // Imposta il tipo di grafico come torta
            chart2.Series["Serie1"].IsValueShownAsLabel = true; // Mostra il valore su ogni segmento
            chart2.Series["Serie1"].Label = "#PERCENT"; // Mostra la percentuale sul grafico
            chart2.Series["Serie1"].BorderWidth = 2; // Aggiungi bordo ai segmenti della torta



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
    }
}
