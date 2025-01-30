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
        private DateTime dataSelezionata;
        public DatiPrenotazioneSubmit(Ristorante ristorante, FormPrenotazione formPrenotazione, DateTime dataSelezionata)
        {
            this.ristorante = ristorante;
            bl = new BlPrenotazioni();
            this.formPrenotazione = formPrenotazione;
            this.dataSelezionata = dataSelezionata;
            InitializeComponent();
        }

        private void DatiPrenotazioneSubmit_Load(object sender, EventArgs e)
        {
            MessageBox.Show(dataSelezionata.ToString());
            textBox3.Text = ristorante.GetNumPosti().ToString();
            textBoxIdRist.Text = ristorante.GetIDRistorante().ToString();
            dateTimePicker1.Value = dataSelezionata.Date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idRistorante = Convert.ToInt32(textBoxIdRist.Text);
            string username = textBox1.Text;
            DateTime dataEOraCorrente = DateTime.Now;
            DateTime dataSelezionata = dateTimePicker1.Value;
            int numeroPersone = Convert.ToInt32(textBox4.Text);

            Prenotazione prenotazione = new Prenotazione(idRistorante, username, dataEOraCorrente, dataSelezionata, numeroPersone);
            bl.AggiungiPrenotazione(prenotazione);

            //int posti = Convert.ToInt32(formPrenotazione.GetPostiTotali()) - numeroPersone;
            //formPrenotazione.GetPostiDisponibili().Text = posti.ToString();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
