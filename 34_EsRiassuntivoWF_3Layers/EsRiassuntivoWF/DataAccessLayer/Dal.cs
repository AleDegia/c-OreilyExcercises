//metto i metodi che interagiscono col db
using EsRiassuntivoWF;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System;
using GestioneBiblioteca3;


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
                    string name = row["Name"].ToString();
                    string category = row["Category"].ToString();
                    double price = Convert.ToDouble(row["Price"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    string title = row["Title"].ToString();
                    string description = row["Description"].ToString();
                    string image = row["Image"].ToString();


                    //faccio oggetto Magazine con i dati del DataTable
                    Magazine magazine = new Magazine(name, category, price, quantity, title, description, image);
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

    }


}