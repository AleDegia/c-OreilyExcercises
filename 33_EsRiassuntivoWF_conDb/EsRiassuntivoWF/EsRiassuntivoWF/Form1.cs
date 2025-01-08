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
using GestioneBiblioteca;

namespace EsRiassuntivoWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //DateTime publicationDate = new DateTime(2008, 6, 1);
            //DateTime publicationDate2 = new DateTime(1997, 6, 26);
            //Book book = new Book("Libro Cronache", "Adventure", 29.99, 5, 1275, "Le cronache di Narnia", "C.S. Lewis", publicationDate);
            //Book book2 = new Book("Libro Harry Potter", "Fantasy", 25.99, 16, 654, "Harry Potter", "J. K. Rowling", publicationDate2);
            //Book book3 = new Book("Libro Cronache", "Adventure", 29.99, 5, 1275, "Le cronache di Narnia", "C.S. Lewis", publicationDate);
            //Magazine magazine = new Magazine("Rivista Focus", "Scienza", 9.99, 13, "Focus", "Bella rivista", "modella.png");

            //Library.Products.Add(book);
            //Library.Products.Add(book2);
            //Library.Products.Add(magazine);
            //string connectionString = ConfigurationManager.ConnectionStrings["EsRiassuntivoWF.Properties.Settings.LibraryDBConnectionString"].ConnectionString;
            //SqlConnection sqlConnection = new SqlConnection(connectionString);


            //lblBalance.Text = "100";

            //foreach (LibraryProduct product in Library.Products)
            //    Console.WriteLine(product.Name);

            //foreach (LibraryProduct product in Library.Products)
            //    libraryProducts.Items.Add(product.Name);
        }

        Client currentClient = new Client(100);
        ClientInventory inventory = new ClientInventory();
        string connectionString;
        List<LibraryProduct> libraryItems = new List<LibraryProduct>();
        InventoryForm inventoryForm = new InventoryForm();


        private void button1_Click(object sender, EventArgs e)
        {
            //se il prodotto è disponibile in magazzino(Library)
            string existingProductName = label2.Text;
            var existingProduct = libraryItems.FirstOrDefault(p => p.Name == existingProductName);
            Console.WriteLine(existingProduct);
            double money = currentClient.GetMoney();    //va messo globalmente 
            money -= existingProduct.Price;
            currentClient.SetMoney(money);
            lblBalance.Text = money.ToString();

            


            //bookProduct.BuyBook(name, quantity, ref availableMoney, Inventory, existingProduct);
            if (existingProduct is Book)
            {
                if (existingProduct != null && money >= 0)
                {
                    var bookProduct = (Book)existingProduct;
                    //aggiungo prodotto a inventario cliente
                    LibraryProduct purchasedProduct = new Book(
                       bookProduct.Name,
                       bookProduct.Category,
                       bookProduct.Price,
                       bookProduct.Quantity,
                       bookProduct.GetPagesNumber(),
                       bookProduct.GetTitle(),
                       bookProduct.GetAuthor(),
                       bookProduct.GetPublishingDate()
                   );
                    //il problema è che faccio un form nuovo ogni volta
                    inventory.Products.Add(purchasedProduct);
                    MessageBox.Show("Acquisto avvenuto con successo");
                    
                        //InventoryForm inventoryForm = new InventoryForm();
                    inventoryForm.AddProductToList(purchasedProduct.Name);
                    inventoryForm.Show();
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show("Non hai abbastanza soldi");
                    //return false;
                }

            }
            else if (existingProduct is Magazine)
            {
                if (existingProduct != null && money >= 0)
                {
                    Magazine magazineProduct = (Magazine)existingProduct;
                    LibraryProduct purchasedProduct = new Magazine(
                        magazineProduct.Name,
                        magazineProduct.Category,
                        magazineProduct.Price,
                        magazineProduct.Quantity,
                        magazineProduct.GetTitle(),      //trovare un modo per accedere tenendo private -> faccio il metodo direttamente nella sua classe
                        magazineProduct.GetDescription(),
                        magazineProduct.GetImg()
                    );
                    //for (int n = 0; n < quantity; n++)
                        inventory.Products.Add(purchasedProduct);
                    Console.WriteLine("Acquisto avvenuto con successo");

                    inventoryForm.AddProductToList(purchasedProduct.Name);
                    inventoryForm.Show();
                    this.Hide();
                }

                else
                {
                    Console.WriteLine("Non hai abbastanza soldi");
                    //return false;
                }
            }
            //return true;
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["EsRiassuntivoWF.Properties.Settings.LibraryDBConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            ShowProducts(connectionString);



            lblBalance.Text = "100";


            /*non serve piu perchè popolo la listBox con ShowProducts()*/
            //foreach (LibraryProduct product in Library.Products)
            //    libraryProducts.Items.Add(product.Name);


        }

        private void ShowProducts(string connectionString)
        {
            //    try
            //    {
            //        //seleziono tutto da Animal e lo unisco a ZooAnimal se l'id 
            //        string query = "select * from BookTb";

            //        //Il SqlDataAdapter si occupa di:
            //        //Eseguire la query sul database per recuperare i dati.
            //        //Riempire una struttura dati in memoria, come una DataTable, con i dati restituiti dalla query.
            //        SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);  //metto sqlCommand al posto di query, sqlConnection

            //        //using rilascia le risorse quando non sono piu necessarie (grazie a Dispose() di IDisposable)
            //        using (adapter)
            //        {
            //            DataTable productsTable = new DataTable();   //creo DataTable vuoto
            //            adapter.Fill(productsTable);  //esegue query e popola la DataTable con i dati restituiti
            //                                        //Dopo l'esecuzione di questa riga, la DataTable conterrà tutte le righe della tabella Books del database.

            //            //la lista mostrerà per ogni elemento il valore della proprietà 'Location' (del db)
            //            libraryProducts.DisplayMember = "Name";

            //            //prendo i dati contenuti nel DataTable in forma di un oggetto di tipo DataView.
            //            libraryProducts.DataSource = productsTable;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }

            try
            {
                string queryBooks = "SELECT * FROM BookTb"; // Tabella dei libri
                string queryMagazines = "SELECT * FROM MagazinesTb"; // Tabella delle riviste

                // Recupera i libri dal database
                SqlDataAdapter adapterBooks = new SqlDataAdapter(queryBooks, connectionString);
                using (adapterBooks)
                {
                    DataTable booksTable = new DataTable();
                    adapterBooks.Fill(booksTable); // Popola il DataTable con i dati dei libri

                    // Aggiungi i libri alla lista libraryItems
                    foreach (DataRow row in booksTable.Rows)
                    {
                        string name = row["Name"].ToString();
                        string category = row["Category"].ToString();
                        double price = Convert.ToDouble(row["Price"]);
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        int pages = Convert.ToInt32(row["PagesNumber"]);
                        string title = row["Title"].ToString();
                        string author = row["Author"].ToString();
                        DateTime publishingDate = Convert.ToDateTime(row["PublishingDate"]);

                        Book book = new Book(name, category, price, quantity, pages, title, author, publishingDate);
                        libraryItems.Add(book); // Aggiungi il libro alla lista
                    }
                }

                // Recupera le riviste dal database
                SqlDataAdapter adapterMagazines = new SqlDataAdapter(queryMagazines, connectionString);
                using (adapterMagazines)
                {
                    DataTable magazinesTable = new DataTable();
                    adapterMagazines.Fill(magazinesTable); // Popola il DataTable con i dati delle riviste

                    // Aggiungi le riviste alla lista libraryItems
                    foreach (DataRow row in magazinesTable.Rows)
                    {
                        string name = row["Name"].ToString();
                        string category = row["Category"].ToString();
                        double price = Convert.ToDouble(row["Price"]);
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        string title = row["Title"].ToString();
                        string description = row["Description"].ToString();
                        string image = row["Image"].ToString();

                        Magazine magazine = new Magazine(name, category, price, quantity, title, description, image);
                        libraryItems.Add(magazine); // Aggiungi la rivista alla lista
                    }
                }

                // Imposta la ListBox per visualizzare i nomi degli oggetti
                libraryProducts.DisplayMember = "Name"; // Mostra la proprietà 'Name'
                libraryProducts.DataSource = libraryItems; // Imposta la lista come DataSource

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
