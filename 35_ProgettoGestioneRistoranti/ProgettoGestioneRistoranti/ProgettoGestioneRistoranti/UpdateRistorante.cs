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
        private ElencoRistoranti elencoRistoranti;
        public UpdateRistorante()
        {
            InitializeComponent();
            blRistoranti = new BlRistoranti();
            //elencoRistoranti = new ElencoRistoranti();
        }

        public UpdateRistorante(Ristorante ristorante, ElencoRistoranti elencoRistoranti)
        {
            InitializeComponent();
            this.ristorante = ristorante;
            blRistoranti = new BlRistoranti();
            this.elencoRistoranti = elencoRistoranti;
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

        private void button1_Click(object sender, EventArgs e)
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

            var dataGridView1 = elencoRistoranti.GetDataGridView();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();


            dataGridView1.Columns.Add("IDRistorante", "ID Ristorante");
            dataGridView1.Columns.Add("Tipologia", "Tipologia");
            dataGridView1.Columns.Add("Indirizzo", "Indirizzo");
            dataGridView1.Columns.Add("RagioneSociale", "Ragione Sociale");
            dataGridView1.Columns.Add("PartitaIva", "Partita IVA");
            dataGridView1.Columns.Add("NumPosti", "Numero Posti");
            dataGridView1.Columns.Add("PrezzoMedio", "Prezzo Medio");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("Citta", "Città");

            var ristoranti = blRistoranti.GetRistorantiFiltrati("", "", 0);

            // Aggiungi manualmente le righe
            foreach (var rist in ristoranti)
            {
                dataGridView1.Rows.Add(
                    rist.GetIDRistorante(),
                    rist.GetTipologia(),
                    rist.GetIndirizzo(),
                    rist.GetRagioneSociale(),
                    rist.GetPartitaIva(),
                    rist.GetNumPosti(),
                    rist.GetPrezzoMedio(),
                    rist.GetTelefono(),
                    rist.GetCitta()
                );
            }

            elencoRistoranti.SetDataGridView(dataGridView1);

            this.Hide();
        }
    }
}
