using BLLL;
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
using UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProgettoGestioneRistoranti
{
    public partial class InsertUtente : Form
    {
        private BlUtenti bl;
        private ElencoUtenti elencoUtenti;
        public InsertUtente(ElencoUtenti elencoUtenti)
        {
            InitializeComponent();
            bl = new BlUtenti();
            this.elencoUtenti = elencoUtenti;
        }

        public InsertUtente()
        {
            InitializeComponent();
            bl = new BlUtenti();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InsertUtente_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
                string username = textBox1.Text;
                string password = textBox2.Text;
                bool isAdministrator = Convert.ToBoolean(textBox8.Text);
                string descrizione = textBox4.Text;
                string email = textBox3.Text;
                string telefono = textBox7.Text;
                string citta = textBox11.Text;

                Utente utente = new Utente(username, password, isAdministrator, descrizione, email, telefono, citta);

                // Aggiorna il prodotto nel database
                bl.AggiungiUtente(utente);

                if (elencoUtenti != null)
                {
                    var dataGridView1 = elencoUtenti.GetDataGridView();
                    elencoUtenti.CleanDataGridView();
                    dataGridView1.Columns.Clear();

                    elencoUtenti.AggiungiColonne();

                    var utenti = bl.GetUtenti();

                    // Aggiungi manualmente le righe
                    elencoUtenti.AggiungiRighe(utenti);

                    elencoUtenti.SetDataGridView(dataGridView1);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("registrazione avvenuta con successo");
                    this.Hide();
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
