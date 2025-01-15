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
using EsRiassuntivoWF.BLL;

namespace EsRiassuntivoWF
{
    public partial class UpdateForm : Form
    {
        private LibraryService libraryService;
        private Form1 form1;
        public UpdateForm(Form1 form1)
        {
            InitializeComponent();
            libraryService = new LibraryService();
            this.form1 = form1;
        }
        

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            //form1 = new Form1();
        }

        private void NameTxtbox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
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
            int pages = Convert.ToInt32(TextBox3.Text);
            string title = TextBox4.Text;
            string author = TextBox5.Text;
            DateTime publishingDate = DateTime.TryParse(TextBox6.Text, out var pd) ? pd : DateTime.MinValue;

            Book book = new Book(id, name, category, price, quantity, pages, title, author, publishingDate);

            // Aggiorna il prodotto nel database
            libraryService.UpdateBooks(book);
            //ogni volta che avviene un aggiornamento devo caricare la lista di libri coi dati modificati
            form1.ShowProducts();
            form1.Hide();

            this.Hide();
            form1.Show();   //perche senza questo nuovo show non aggiorna i dati?
        }
    }
}
