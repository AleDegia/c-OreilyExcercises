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

        public void AggiungiColonne()
        {
            dataGridView1.Columns.Add("UserName", "Username");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("IsAdministrator", "IsAdministrator");
            dataGridView1.Columns.Add("Descrizione", "Descrizione");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("Citta", "Città");
        }

        public void AggiungiRighe(List<Utente> utenti)
        {
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

        private Utente GetUtenteFromDataGridView(DataGridViewRow row)
        {
            string userName = row.Cells["UserName"].Value.ToString();
            string password = row.Cells["Password"].Value.ToString();
            bool isAdministrator = Convert.ToBoolean(row.Cells["IsAdministrator"].Value);
            string descrizione = row.Cells["Descrizione"].Value.ToString();
            string email = row.Cells["Email"].Value.ToString();
            string telefono = row.Cells["Telefono"].Value.ToString();
            string citta = row.Cells["Citta"].Value.ToString();

            return utente = new Utente(
                userName,
                password,
                isAdministrator,
                descrizione,
                email,
                telefono,
                citta
            );
        }

        public void CleanDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        private void ElencoUtenti_Load(object sender, EventArgs e)
        {
            AggiungiColonne();
            List<Utente> utenti = blUtenti.GetUtenti();
            AggiungiRighe(utenti);
            dataGridView1.Columns["Password"].Visible = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            insertUtente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //prendo le info (id) del ristorante selezionato
            if (dataGridView1.SelectedRows.Count > 0)
            {

                //riga selezionata
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // recupero valori celle
                utente = GetUtenteFromDataGridView(row);
                updateUtente = new UpdateUtente(utente, this);
                updateUtente.Show();
            }
            else
            {
                MessageBox.Show("Seleziona un ristorante dalla lista.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                CleanDataGridView();

                AggiungiColonne();

                var utenti = blUtenti.GetUtenti();

                // Aggiungi manualmente le righe
                AggiungiRighe(utenti);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
