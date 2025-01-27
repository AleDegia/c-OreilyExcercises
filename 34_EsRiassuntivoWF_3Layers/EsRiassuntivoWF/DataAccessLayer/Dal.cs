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
using System.Diagnostics;
using System.Net;


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
                else if(product is Magazine magazine)
                {
                    string saveProd = "INSERT into purchasedMagazines (Id, Name, Category, Price, Quantity, Title, Description, Image) VALUES (@Id,@Name,@Category, @Price, @Quantity, @Title, @Description, @Image)";
                    using (SqlCommand querySaveStaff = new SqlCommand(saveProd))
                    {
                        querySaveStaff.Connection = openCon;
                        openCon.Open();

                        querySaveStaff.Parameters.AddWithValue("@Id", magazine.Id);
                        querySaveStaff.Parameters.AddWithValue("@Name", magazine.Name);
                        querySaveStaff.Parameters.AddWithValue("@Category", magazine.Category);
                        querySaveStaff.Parameters.AddWithValue("@Price", magazine.Price);
                        querySaveStaff.Parameters.AddWithValue("@Quantity", magazine.Quantity);
                        querySaveStaff.Parameters.AddWithValue("@Title", magazine.GetTitle());
                        querySaveStaff.Parameters.AddWithValue("@Description", magazine.GetDescription());
                        querySaveStaff.Parameters.AddWithValue("@Image", magazine.GetImg());

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

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            string query = "SELECT * FROM BooksTb";

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


        public List<Magazine> GetAllMagazines()
        {
            var magazines = new List<Magazine>();
            string query = "SELECT * FROM MagazinesTb";

            using (var adapter = new SqlDataAdapter(query, connectionString))
            {
                var booksTable = new DataTable();
                adapter.Fill(booksTable);

                foreach (DataRow row in booksTable.Rows)
                {
                    magazines.Add(new Magazine(
                        Convert.ToInt32(row["Id"]),
                        row["Name"].ToString(),
                        row["Category"].ToString(),
                        Convert.ToDouble(row["Price"]),
                        Convert.ToInt32(row["Quantity"]),
                        row["Title"].ToString(),
                        row["Description"].ToString(),
                        row["Image"].ToString()
                    ));
                }
            }

            return magazines;
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
                        command.Parameters.AddWithValue("@name", name);

                        // Eseguo la query
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())  // Se trova un record
                            {
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
                    Console.WriteLine(ex.ToString()); 
                }

                return book;
            }
        }


        public void UpdateBooks(Book prod)
        {
            string query = $"UPDATE BooksTb SET Name = @Name, Category = @Category,  Price = @Price,  Quantity = @Quantity,  PagesNumber = @PagesNumber, Title = @Title, Author = @Author, PublishingDate = @PublishingDate WHERE Id = @BookId";

            using (SqlConnection openCon = new SqlConnection(connectionString))  // Connetto al DB
            {
                try
                {
                    openCon.Open();  

                    //UPDATE table1 SET table1.column = table2.expression1 FROM table1 [WHERE conditions];
                    using (SqlCommand cmd = new SqlCommand(query, openCon))  // Prepara la query
                    {
                        cmd.Parameters.AddWithValue("@Name", prod.Name);
                        cmd.Parameters.AddWithValue("@Category", prod.Category);
                        cmd.Parameters.AddWithValue("@Price", prod.Price);
                        cmd.Parameters.AddWithValue("@Quantity", prod.Quantity);
                        cmd.Parameters.AddWithValue("@PagesNumber", prod.GetPagesNumber());
                        cmd.Parameters.AddWithValue("@Title", prod.GetTitle());
                        cmd.Parameters.AddWithValue("@Author", prod.GetAuthor());
                        cmd.Parameters.AddWithValue("@PublishingDate", prod.GetPublishingDate());
                        cmd.Parameters.AddWithValue("@BookId", prod.Id); 

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Prodotto Aggiornato!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("qualcosa non ha funzionato");
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        public void UpdateMagazine(Magazine prod)
        {
            string query = $"UPDATE MagazinesTb SET Name = @Name, Category = @Category,  Price = @Price,  Quantity = @Quantity, Title = @Title, Description = @Description, Image = @Image WHERE Id = @BookId";

            using (SqlConnection openCon = new SqlConnection(connectionString))  // Connetto al DB
            {
                try
                {
                    openCon.Open();

                    //UPDATE table1 SET table1.column = table2.expression1 FROM table1 [WHERE conditions];
                    using (SqlCommand cmd = new SqlCommand(query, openCon))  // Prepara la query
                    {
                        cmd.Parameters.AddWithValue("@Name", prod.Name);
                        cmd.Parameters.AddWithValue("@Category", prod.Category);
                        cmd.Parameters.AddWithValue("@Price", prod.Price);
                        cmd.Parameters.AddWithValue("@Quantity", prod.Quantity);
                        cmd.Parameters.AddWithValue("@Title", prod.GetTitle());
                        cmd.Parameters.AddWithValue("@Description", prod.GetDescription());
                        cmd.Parameters.AddWithValue("@Image", prod.GetImg());
                        cmd.Parameters.AddWithValue("@BookId", prod.Id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Prodotto Aggiornato!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("qualcosa non ha funzionato");
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteProduct(string name)
        {
            string query = $"DELETE FROM BooksTb WHERE Title = @name";
            using (SqlConnection openCon = new SqlConnection(connectionString))
            {
                try
                {
                    openCon.Open();
                    using (SqlCommand cmd = new SqlCommand(query, openCon))
                    {
                        // Aggiungi il parametro con il valore della variabile name
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("qualcosa non ha funzionato");
                    Console.WriteLine(ex.ToString());
                }
             }
        }   
    }
}