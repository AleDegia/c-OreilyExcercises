using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace ProgettoGestioneRistoranti
{
    public partial class UpdateRistorante : Form
    {
        private BlRistoranti blRistoranti;
        //private ElencoRistoranti elencoRistoranti;
        private Ristorante ristorante;
        public UpdateRistorante()
        {
            InitializeComponent();
            blRistoranti = new BlRistoranti();
            //elencoRistoranti = new ElencoRistoranti();
        }

        public UpdateRistorante(Ristorante ristorante)
        {
            InitializeComponent();
            this.ristorante = ristorante;
            blRistoranti = new BlRistoranti();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Leggo i valori dalle TextBox
            int idRistorante = Convert.ToInt32(textBox9.Text);
            int tipologia = Convert.ToInt32(textBox1.Text);
            string indirizzo = textBox2.Text;
            string ragioneSociale = textBox8.Text;
            string partitaIva = textBox4.Text;
            int numPosti = Convert.ToInt32(textBox3.Text);
            decimal prezzoMedio = Convert.ToDecimal(textBox5.Text);
            string telefono = textBox7.Text;
            string citta = textBox11.Text;

            Ristorante ristorante = new Ristorante(idRistorante, tipologia, indirizzo, ragioneSociale, partitaIva, numPosti, prezzoMedio, telefono, citta);

            blRistoranti.ModificaRistorante(ristorante);
            this.Hide();
        }

        private void UpdateRistorante_Load(object sender, EventArgs e)
        {
            //Ristorante ristorante = elencoRistoranti.GetRistorante();
            textBox9.Text = ristorante.GetIDRistorante().ToString();
            textBox1.Text = ristorante.GetTipologia().ToString();
            textBox2.Text = ristorante.GetIndirizzo().ToString();
            textBox8.Text = ristorante.GetRagioneSociale().ToString();
            textBox4.Text = ristorante.GetPartitaIva().ToString();
            textBox3.Text = ristorante.GetNumPosti().ToString();
            textBox5.Text = ristorante.GetPrezzoMedio().ToString();
            textBox7.Text = ristorante.GetTelefono().ToString();    
            textBox11.Text = ristorante.GetCitta().ToString();
        }
    }
}
