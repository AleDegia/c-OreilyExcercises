//using DevExpress.Utils.Win.Hook;
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

        private Ristorante RecuperaCampiECreaOgg()
        {
            char tipologiaSelezionata = comboBox1.Text[0];
            int tipologia = Convert.ToInt32(tipologiaSelezionata.ToString());
            string indirizzo = textBox2.Text;
            string ragioneSociale = textBox8.Text;
            string partitaIva = textBox4.Text;
            int numCorsi = Convert.ToInt32(textBox3.Text);
            decimal prezzoMedio = Convert.ToDecimal(textBox5.Text);
            string telefono = textBox7.Text;
            string citta = textBox11.Text;

            Ristorante ristorante = new Ristorante(0, tipologia, indirizzo, ragioneSociale, partitaIva, numCorsi, prezzoMedio, telefono, citta);
            return ristorante;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Leggo i valori dalle TextBox
                Ristorante ristorante = RecuperaCampiECreaOgg();

                // Aggiorna il prodotto nel database
                bl.AggiungiRistorante(ristorante);
                //elencoRistoranti = new ElencoRistoranti();
                var dataGridView1 = elencoRistoranti.GetDataGridView();
                elencoRistoranti.CleanDataGridView();
                //dataGridView1.Columns.Clear();

                dataGridView1.Columns.Clear();
                elencoRistoranti.AggiungiColonne();


                var ristoranti = bl.GetRistorantiFiltrati();

                // Aggiungi manualmente le righe
                elencoRistoranti.AggiungiRighe(ristoranti);


                elencoRistoranti.SetDataGridView(dataGridView1);
                this.Hide();
            }
            catch (FormatException ex)
            {
                // Gestione errori di conversione (ad esempio errore nella conversione del boolean)
                MessageBox.Show("Formato dei dati errato. Assicurati che tutti i campi siano corretti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Errore di formato: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Gestione generica di errori imprevisti
                MessageBox.Show("Si è verificato un errore durante l'operazione. Riprova più tardi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Errore generale: " + ex.Message);
            }

        }
    }
}
