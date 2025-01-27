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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProgettoGestioneRistoranti
{
    public partial class UpdateUtente : Form
    {
        private BlUtenti blUtenti;
        private ElencoUtenti elencoUtenti;
        private Utente utente;
        public UpdateUtente(Utente utente, ElencoUtenti elenco)
        {
            InitializeComponent();
            blUtenti = new BlUtenti();
            elencoUtenti = elenco;
            this.utente = utente;
        }

        private void saveButton_Click(object sender, EventArgs e)
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

            blUtenti.ModificaUtente(utente);

            var dataGridView1 = elencoUtenti.GetDataGridView();
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

            var utenti = blUtenti.GetUtenti();

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

        private void UpdateUtente_Load(object sender, EventArgs e)
        {
            textBox1.Text = utente.GetUserName().ToString();
            textBox2.Text = utente.GetPassword().ToString();
            textBox8.Text = utente.GetIsAdministrator().ToString();
            textBox4.Text = utente.GetDescrizione().ToString();
            textBox3.Text = utente.GetEmail().ToString();
            textBox7.Text = utente.GetTelefono().ToString();
            textBox11.Text = utente.GetCitta().ToString();
        }

        private void saveButton_Click_1(object sender, EventArgs e)
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

            blUtenti.ModificaUtente(utente);

            var dataGridView1 = elencoUtenti.GetDataGridView();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();


            dataGridView1.Columns.Add("UserName", "Username");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("IsAdministrator", "IsAdministrator");
            dataGridView1.Columns.Add("Descrizione", "Descrizione");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("Citta", "Città");

            var utenti = blUtenti.GetUtenti();

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
