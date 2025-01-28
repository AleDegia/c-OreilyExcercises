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
            var dataGridView1 = elencoUtenti.GetDataGridView();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("UserName", "Username");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("IsAdministrator", "IsAdministrator");
            dataGridView1.Columns.Add("Descrizione", "Descrizione");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("Citta", "Città");

            var utenti = bl.GetUtenti();

            // Aggiungi manualmente le righe
            foreach (var rist in utenti)
            {
                dataGridView1.Rows.Add(
                    rist.GetUserName(),
                    rist.GetPassword(),
                    rist.GetIsAdministrator(),
                    rist.GetDescrizione(),
                    rist.GetEmail(),
                    rist.GetTelefono(),
                    rist.GetCitta()
                );
            }

            elencoUtenti.SetDataGridView(dataGridView1);
            this.Hide();
        }
    }
}
