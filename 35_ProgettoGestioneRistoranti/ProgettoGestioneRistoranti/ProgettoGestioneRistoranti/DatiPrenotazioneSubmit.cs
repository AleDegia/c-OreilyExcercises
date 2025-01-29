using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UI;
using BLLL;

namespace ProgettoGestioneRistoranti
{
    public partial class DatiPrenotazioneSubmit : Form
    {
        private Ristorante ristorante;
        private BlPrenotazioni bl;
        private FormPrenotazione formPrenotazione;
        public DatiPrenotazioneSubmit(Ristorante ristorante, FormPrenotazione formPrenotazione)
        {
            this.ristorante = ristorante;
            bl = new BlPrenotazioni();
            this.formPrenotazione = formPrenotazione;
            InitializeComponent();
        }

        private void DatiPrenotazioneSubmit_Load(object sender, EventArgs e)
        {
            textBox3.Text = ristorante.GetNumPosti().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idPrenotazione = 0;
            int idRistorante = Convert.ToInt32(textBoxIdRist.Text);
            string username = textBox1.Text;
            DateTime dataEOraCorrente = DateTime.Now;
            DateTime dataSelezionata = dateTimePicker1.Value;
            int numeroPersone = Convert.ToInt32(textBox4.Text);

            Prenotazione prenotazione = new Prenotazione(idPrenotazione, idRistorante, username, dataEOraCorrente, dataSelezionata, numeroPersone);
            bl.AggiungiPrenotazione(prenotazione);

            int posti = Convert.ToInt32(formPrenotazione.GetPostiTotali()) - numeroPersone;
            formPrenotazione.GetPostiDisponibili().Text = posti.ToString();
            this.Hide();
        }
    }
}
