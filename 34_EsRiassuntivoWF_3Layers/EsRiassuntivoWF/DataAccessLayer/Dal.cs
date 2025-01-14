//metto i metodi che interagiscono col db
using EsRiassuntivoWF;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System;
using GestioneBiblioteca3;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Collections;


namespace EsRiassuntivoWF.DAL
{

    public class Dal
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EsRiassuntivoWF.Properties.Settings.LibraryDBConnectionString"].ConnectionString;

        public string GetConnectionString() //non deve uscire dal DAL la connection string
        {
            return connectionString;
        }
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            string query = "SELECT * FROM BooksTb ORDER BY Title ASC";

            using (var adapter = new SqlDataAdapter(query, connectionString))
            {
                var booksTable = new DataTable();
                adapter.Fill(booksTable);

                foreach (DataRow row in booksTable.Rows)
                {
                    books.Add(new Book(
                        Convert.ToInt32(row["Id"]),
                        row["Name"].ToString(),
                        row["Category"].ToString(),
                        Convert.ToDouble(row["Price"]),
                        Convert.ToInt32(row["Quantity"]),
                        Convert.ToInt32(row["PagesNumber"]),
                        row["Title"].ToString(),
                        row["Author"].ToString(),
                        Convert.ToDateTime(row["PublishingDate"])
                    ));
                }
            }

            return books;
        }

        public List<Magazine> GetMagazines()
        {
            var magazines = new List<Magazine>();
            string query = "SELECT * FROM MagazinesTb ORDER BY Title ASC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);

            using (adapter)
            {
                DataTable magazinesTable = new DataTable();
                adapter.Fill(magazinesTable); // Popola il DataTable con i dati delle riviste

                // Aggiungo le riviste alla lista libraryItems
                foreach (DataRow row in magazinesTable.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string name = row["Name"].ToString();
                    string category = row["Category"].ToString();
                    double price = Convert.ToDouble(row["Price"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    string title = row["Title"].ToString();
                    string description = row["Description"].ToString();
                    string image = row["Image"].ToString();


                    //faccio oggetto Magazine con i dati del DataTable
                    Magazine magazine = new Magazine(id, name, category, price, quantity, title, description, image);
                    magazines.Add(magazine);
                    //libraryItems.Add(magazine); // Aggiungi la rivista alla lista
                }
            }

            // Imposta la ListBox per visualizzare i nomi degli oggetti
            //libraryProducts.DisplayMember = "Title"; // Mostra la proprietà 'Name'
            //dico che prenderò i dati per riempire la listBox libraryProducts dalla list libraryItems
            //libraryProducts.DataSource = libraryItems;

            return magazines;
        }


        public bool InsertProduct(LibraryProduct product)
        {
            using (SqlConnection openCon = new SqlConnection(connectionString))
            {
                if (product is Book book)
                {
                    string saveProd = "INSERT into purchasedBooks (Id, Name, Category, Price, Quantity, PagesNumber, Title, Author, PublishingDate) VALUES (@Id,@Name,@Category, @Price, @Quantity, @PagesNumber, @Title, @Author, @PublishingDate)";
                    using (SqlCommand querySaveStaff = new SqlCommand(saveProd))
                    {
                        querySaveStaff.Connection = openCon;
                        openCon.Open();

                        querySaveStaff.Parameters.AddWithValue("@Id", book.Id);
                        querySaveStaff.Parameters.AddWithValue("@Name", book.Name);
                        querySaveStaff.Parameters.AddWithValue("@Category", book.Category);
                        querySaveStaff.Parameters.AddWithValue("@Price", book.Price);
                        querySaveStaff.Parameters.AddWithValue("@Quantity", book.Quantity);
                        querySaveStaff.Parameters.AddWithValue("@PagesNumber", book.GetPagesNumber());
                        querySaveStaff.Parameters.AddWithValue("@Title", book.GetTitle());
                        querySaveStaff.Parameters.AddWithValue("@Author", book.GetAuthor());
                        querySaveStaff.Parameters.AddWithValue("@PublishingDate", book.GetPublishingDate());

                        try
                        {
                            querySaveStaff.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hai già acquistato questo libro");
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public List<Book> GetBooksFromInventory()
        {
            var books = new List<Book>();
            string query = "SELECT * FROM PurchasedBooks ORDER BY Title ASC";

            using (var adapter = new SqlDataAdapter(query, connectionString))
            {
                var booksTable = new DataTable();
                adapter.Fill(booksTable);

                foreach (DataRow row in booksTable.Rows)
                {
                    books.Add(new Book(
                        Convert.ToInt32(row["Id"]),
                        row["Name"].ToString(),
                        row["Category"].ToString(),
                        Convert.ToDouble(row["Price"]),
                        Convert.ToInt32(row["Quantity"]),
                        Convert.ToInt32(row["PagesNumber"]),
                        row["Title"].ToString(),
                        row["Author"].ToString(),
                        Convert.ToDateTime(row["PublishingDate"])
                    ));
                }
            }

            return books;
        }

        public Book GetBook(string name)
        {
            string query = "SELECT TOP 1 * FROM BooksTb WHERE Title = @name";
            Book book = null;  // Oggetto da restituire

            using (SqlConnection openCon = new SqlConnection(connectionString))  // Connessione al DB
            {
                try
                {
                    openCon.Open();  // Apre la connessione

                    using (SqlCommand command = new SqlCommand(query, openCon))  // Prepara la query
                    {
                        // Aggiungi il parametro per prevenire SQL Injection
                        command.Parameters.AddWithValue("@name", name);

                        // Esegui la query e ottieni il risultato
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())  // Se trova un record
                            {
                                // Mappa i dati letti in un oggetto Book
                                book = new Book(
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetString(reader.GetOrdinal("Category")),
                                    reader.GetDouble(reader.GetOrdinal("Price")),
                                    reader.GetInt32(reader.GetOrdinal("Quantity")),
                                    reader.GetInt32(reader.GetOrdinal("PagesNumber")),
                                    reader.GetString(reader.GetOrdinal("Title")),
                                    reader.GetString(reader.GetOrdinal("Author")),
                                    reader.GetDateTime(reader.GetOrdinal("PublishingDate"))
                                    );
                            
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                }

                return book;
            }
        }
    }
}