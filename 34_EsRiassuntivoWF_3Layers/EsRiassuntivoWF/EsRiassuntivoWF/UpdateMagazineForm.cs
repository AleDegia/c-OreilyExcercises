using EsRiassuntivoWF.BLL;
using GestioneBiblioteca3;
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

namespace EsRiassuntivoWF
{
    public partial class UpdateMagazineForm : Form
    {
        private Form1 form1;
        private LibraryService libraryService;
        public UpdateMagazineForm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            libraryService = new LibraryService();
        }

        private void UpdateMagazineForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Leggi i valori dalle TextBox
            int id = Convert.ToInt32(TextBox9.Text);
            string name = TextBox7.Text;
            string category = TextBox1.Text;
            double price = Convert.ToDouble(TextBox2.Text);
            int quantity = Convert.ToInt32(TextBox8.Text);
            string title = TextBox3.Text;
            string description = TextBox5.Text;
            string img = TextBox6.Text; 

            Magazine magazine = new Magazine(id, name, category, price, quantity, title, description, img);

            // Aggiorna il prodotto nel database
            libraryService.UpdateMagazine(magazine);
            //ogni volta che avviene un aggiornamento devo caricare la lista di libri coi dati modificati
            form1.ShowProducts();
            //form1.Hide();

            this.Hide();
            form1.Show();   //perche senza questo nuovo show non aggiorna i dati?
        }
    }
}
