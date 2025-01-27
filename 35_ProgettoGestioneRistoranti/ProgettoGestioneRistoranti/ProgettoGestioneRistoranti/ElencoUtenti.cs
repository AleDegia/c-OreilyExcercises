using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLL;
using Models;
using ProgettoGestioneRistoranti;

namespace UI
{
    public partial class ElencoUtenti : Form
    {
        private BlUtenti blUtenti;
        private InsertUtente insertUtente;
        private Utente utente;
        private UpdateUtente updateUtente;
        public ElencoUtenti()
        {
            InitializeComponent();
            blUtenti = new BlUtenti();
            insertUtente = new InsertUtente(this);
        }

        private void ElencoUtenti_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("UserName", "Username");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("IsAdministrator", "IsAdministrator");
            dataGridView1.Columns.Add("Descrizione", "Descrizione");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("Citta", "Città");

            List<Utente> utenti = blUtenti.GetUtenti();

            // Aggiungi manualmente le righe
            foreach (var utente in utenti)
            {
                dataGridView1.Rows.Add(
                    utente.GetUserName(),
                    utente.GetPassword(),
                    utente.GetIsAdministrator(),
                    utente.GetDescrizione(),
                    utente.GetEmail(),
                    utente.GetTelefono(),
                    utente.GetCitta()
                );
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            insertUtente.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //prendo le info (id) del ristorante selezionato
            if (dataGridView1.SelectedRows.Count > 0)
            {

                //riga selezionata
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // recupero valori celle
                string userName = row.Cells["UserName"].Value.ToString();
                string password = row.Cells["Password"].Value.ToString();
                bool isAdministrator = Convert.ToBoolean(row.Cells["IsAdministrator"].Value);
                string descrizione = row.Cells["Descrizione"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();
                string telefono = row.Cells["Telefono"].Value.ToString();
                string citta = row.Cells["Citta"].Value.ToString();

                utente = new Utente(
                    userName,
                    password,
                    isAdministrator,
                    descrizione,
                    email,
                    telefono,
                    citta
                );
                updateUtente = new UpdateUtente(utente, this);
                updateUtente.Show();
            }
            else
            {
                MessageBox.Show("Seleziona un ristorante dalla lista.");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //prendo le info (id) del ristorante selezionato
            if (dataGridView1.SelectedRows.Count > 0)
            {

                //riga selezionata
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                // recupero valore chiave primaria
                string valore = row.Cells[0].Value.ToString();
                MessageBox.Show("valore è " + valore);

                blUtenti.CancellaUtente(valore);
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
                foreach (var utente in utenti)
                {
                    dataGridView1.Rows.Add(
                        utente.GetUserName(),
                        utente.GetPassword(),
                        utente.GetIsAdministrator(),
                        utente.GetDescrizione(),
                        utente.GetEmail(),
                        utente.GetTelefono(),
                        utente.GetCitta()
                    );
                }

            }
        }
    }
}
