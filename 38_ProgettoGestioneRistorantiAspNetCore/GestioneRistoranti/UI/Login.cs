using BLLL;
using Microsoft.Extensions.Configuration;
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

namespace ProgettoGestioneRistoranti
{
    public partial class Login : Form
    {
        private InsertUtente insertUtente;
        private BlUtenti blUtenti;
        private List<Utente> utenti;
        private Homepage homepage;
        public Login(IConfiguration configuration)
        {
            blUtenti = new BlUtenti();
            InitializeComponent();
        }

        public bool VerificaPassword()
        {
            foreach (Utente utente in utenti)
            {
                if (utente.Password.Equals(textBox2.Text))
                    return true;
            }
            return false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertUtente.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //utenti = blUtenti.GetUtenti();
            insertUtente = new InsertUtente();
            // The password character is an asterisk.
            textBox2.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            textBox2.MaxLength = 18;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            //recupero nome utenti del db
           Utente utente = blUtenti.GetUtente(username);
            //verifico presenza utente(username e pass) in tabella Utenti e se c'è -> Homepage
            if(utente == null)
            {
                MessageBox.Show("Utente non trovato.");
                return;
            }
            if(utente.Password != password)
            {
                MessageBox.Show("Password errata.");
                return;
            }
            homepage = new Homepage(utente.UserName);
            homepage.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
