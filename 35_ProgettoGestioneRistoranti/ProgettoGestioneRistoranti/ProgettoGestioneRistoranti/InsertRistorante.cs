using DevExpress.Utils.Win.Hook;
using Engine;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProgettoGestioneRistoranti
{
    public partial class InsertRistorante : Form
    {
        BlRistoranti bl;
        ElencoRistoranti elencoRistoranti;
        private DataGridView dataGridViewRistoranti;
        public InsertRistorante()
        {
            InitializeComponent();
            bl = new BlRistoranti();
            
        }

        public InsertRistorante(ElencoRistoranti elencoRistoranti)
        {
            InitializeComponent();
            bl = new BlRistoranti();
            this.elencoRistoranti = elencoRistoranti;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Leggo i valori dalle TextBox
            int tipologia = Convert.ToInt32(textBox1.Text);
            string indirizzo = textBox2.Text;
            string ragioneSociale = textBox8.Text;
            string partitaIva = textBox4.Text;
            int numCorsi = Convert.ToInt32(textBox3.Text);
            decimal prezzoMedio = Convert.ToDecimal(textBox5.Text);
            string telefono = textBox7.Text;
            string citta = textBox11.Text;

            Ristorante ristorante = new Ristorante(0, tipologia, indirizzo, ragioneSociale, partitaIva, numCorsi, prezzoMedio, telefono, citta);

            // Aggiorna il prodotto nel database
            bl.AggiungiRistorante(ristorante);
            //elencoRistoranti = new ElencoRistoranti();
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

            var ristoranti = bl.GetRistorantiFiltrati("", "", 0);

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertRistorante_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
