using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLLL;
using Engine;
using Models;
using UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProgettoGestioneRistoranti
{
    public partial class UpdatePrenotazione : Form
    {
        private Prenotazione prenotazione;
        private BlPrenotazioni blPrenotazioni;
        private ElencoPrenotazioni elencoPrenotazioni;
        private FormPrenotazione formPrenotazione;
        public UpdatePrenotazione(Prenotazione prenotazione, ElencoPrenotazioni elencoPrenotazioni)
        {
            InitializeComponent();
            this.prenotazione = prenotazione;
            blPrenotazioni = new BlPrenotazioni();
            this.elencoPrenotazioni = elencoPrenotazioni;
        }

        public UpdatePrenotazione(Prenotazione prenotazione, FormPrenotazione formPrenotazione)
        {
            InitializeComponent();
            this.prenotazione = prenotazione;
            blPrenotazioni = new BlPrenotazioni();
            this.formPrenotazione = formPrenotazione;
        }

        private void UpdatePrenotazione_Load(object sender, EventArgs e)
        {
            textBox9.Text = prenotazione.IDPrenotazione.ToString();
            textBox2.Text = prenotazione.IDRistorante.ToString();
            textBox8.Text = prenotazione.NomeUtente.ToString();
            textBox4.Text = prenotazione.DataRichiesta.ToString();
            textBox3.Text = prenotazione.DataPrenotazione.ToString();
            textBox5.Text = prenotazione.NumPersone.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Leggo i valori dalle TextBox
                int idPrenotazione = Convert.ToInt32(textBox9.Text);
            int idRistorante = Convert.ToInt32(textBox2.Text);
            string nomeUtente = textBox8.Text;
            DateTime dataRichiesta = Convert.ToDateTime(textBox4.Text);
            DateTime dataPrenotazione = Convert.ToDateTime(textBox3.Text);
            int numPosti = Convert.ToInt32(textBox5.Text);

            Prenotazione prenotazione2 = new Prenotazione(idRistorante, nomeUtente, dataRichiesta, dataPrenotazione, numPosti);
            
                blPrenotazioni.AggiornaPrenotazioneELog(prenotazione2);
            }
            catch (Exception ex)
            {
                // Mostra l'errore nell'interfaccia utente
                MessageBox.Show($"Si è verificato un errore: {ex.Message}", "Errore");
            }

            if(elencoPrenotazioni!=null)
            {
                var dataGridView1 = elencoPrenotazioni.GetDataGridView1();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                elencoPrenotazioni.AggiungiColonne();

                var prenotazioni = blPrenotazioni.GetPrenotazioni();
                elencoPrenotazioni.AggiungiRighe(prenotazioni);
                elencoPrenotazioni.SetDataGridView(dataGridView1);
                this.Hide();
            }

            else
            {

            }
            
        }
    }
}
