using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestioneBiblioteca3;
using EsRiassuntivoWF.BLL;
using EsRiassuntivoWF.DAL;

namespace EsRiassuntivoWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            libraryService = new LibraryService(); // Inizializza dal nel costruttore
            dal = new Dal();
            updateForm = new UpdateForm(this);
            updateMagazineForm = new UpdateMagazineForm(this);
        }

        Client currentClient = new Client(100);
        ClientInventory inventory = new ClientInventory();
        List<LibraryProduct> libraryItems = new List<LibraryProduct>();
        InventoryForm inventoryForm = new InventoryForm();  //da mettere il new nel Load?
        double spesaTotale = 0;
        private LibraryService libraryService;
        private Dal dal;
        private UpdateForm updateForm;
        private UpdateMagazineForm updateMagazineForm;



        private void button1_Click(object sender, EventArgs e)
        {
            inventoryForm.Show();

            //se il prodotto è disponibile in magazzino(Library)
            //non devo piu recuperare dal label il prodotto ma dal listbox carrello
            List<string> itemsNames = new List<string>();
            foreach (var item in checkout.Items)
            {
                if (item.ToString().Contains("Libro") || item.ToString().Contains("Rivista"))
                    itemsNames.Add(item.ToString());
            }

            foreach (var item in itemsNames)
            {
                var existingProduct = libraryItems.FirstOrDefault(p => p.Name == item);
                Console.WriteLine(existingProduct);
                bool result = libraryService.InsertProduct(existingProduct);
                if (result == false) break;
                double money = currentClient.GetMoney();    //va messo globalmente 
                money -= existingProduct.Price;
                currentClient.SetMoney(money);
                lblBalance.Text = money.ToString();


                LibraryProduct purchasedProduct = libraryService.checkProduct(existingProduct, money);
            
                inventoryForm.AddProductToList(purchasedProduct.Name);
                
                //this.Hide();
               
            }
            checkout.Items.Clear();
            SommaSpesa.Text="";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            // Controlla se c'è un elemento selezionato
            if (libraryProducts.SelectedItem != null)
            {
                // Fai il cast dell'elemento selezionato in LibraryItem
                LibraryProduct selectedItem = (LibraryProduct)libraryProducts.SelectedItem;
                

                // Imposta la proprietà 'Name' nel label
                label2.Text = selectedItem.Name;
                libraryItems.Add(selectedItem);
                checkout.Items.Add(selectedItem.Name);
                checkout.Items.Add(selectedItem.Price);
                spesaTotale += selectedItem.Price;
                SommaSpesa.Text = spesaTotale.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            ShowProducts();
            lblBalance.Text = "100";

            /*non serve piu perchè popolo la listBox con ShowProducts()*/
            //foreach (LibraryProduct product in Library.Products)
            //    libraryProducts.Items.Add(product.Name);
        }



        public void ShowProducts()
        {

            List<LibraryProduct> libraryItems = libraryService.GetLibraryItems();
            libraryProducts.DataSource = libraryItems;
            libraryProducts.DisplayMember = "Title"; //Mostra il titolo dell'articolo
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkout_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (libraryProducts.SelectedItem != null)
            {
                string selectedItem = libraryProducts.SelectedItem.ToString();
                var existingProduct = libraryService.GetProduct(selectedItem.ToString());
                if(existingProduct is Book book)
                MessageBox.Show(
                $"Name: {existingProduct.Name}\nPrice: {existingProduct.Price}\nCategory: {existingProduct.Category}\nPages: {book.GetPagesNumber()} ",
                "Product Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (libraryProducts.SelectedItem != null)
            {
                string selectedItem = libraryProducts.SelectedItem.ToString();
                //prendo i dati dal db e li metto nelle caselle 
                var existingProduct = libraryService.GetProduct(selectedItem.ToString());
                if (existingProduct is Book book)
                {
                    updateForm.TextBox9.Text = existingProduct.Id.ToString();
                    updateForm.TextBox7.Text = existingProduct.Name;
                    updateForm.TextBox1.Text = existingProduct.Category;
                    updateForm.TextBox2.Text = existingProduct.Price.ToString();
                    updateForm.TextBox8.Text = existingProduct.Quantity.ToString();
                    updateForm.TextBox3.Text = book.GetPagesNumber().ToString();
                    updateForm.TextBox4.Text = book.GetTitle().ToString();
                    updateForm.TextBox5.Text = book.GetAuthor();
                    updateForm.TextBox6.Text = book.GetPublishingDate().ToString();
                    updateForm.Show();
                }
                else if(existingProduct is Magazine magazine)
                {
                    updateMagazineForm.TextBox9.Text = existingProduct.Id.ToString();
                    updateMagazineForm.TextBox7.Text = existingProduct.Name;
                    updateMagazineForm.TextBox1.Text = existingProduct.Category;
                    updateMagazineForm.TextBox2.Text = existingProduct.Price.ToString();
                    updateMagazineForm.TextBox8.Text = existingProduct.Quantity.ToString();
                    updateMagazineForm.TextBox3.Text = magazine.GetTitle();
                    updateMagazineForm.TextBox5.Text = magazine.GetDescription();
                    updateMagazineForm.TextBox6.Text = magazine.GetImg();
                    updateMagazineForm.Show();
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (libraryProducts.SelectedItem != null)
            {
                string selectedItem = libraryProducts.SelectedItem.ToString();
                libraryService.DeleteProduct(selectedItem);
                MessageBox.Show("prodotto eliminato");
                ShowProducts();
            }
            else
            {
                Console.WriteLine("Errore");
            }
        }
    }
}
