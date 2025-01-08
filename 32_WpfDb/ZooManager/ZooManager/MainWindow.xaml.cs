using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["ZooManager.Properties.Settings.PrimoDbConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            ShowZoos();
            ShowAllAnimals();

        }

        private void ShowZoos()
        {
            try 
            { 
                //seleziono tutto da Animal e lo unisco a ZooAnimal se l'id 
                string query = "select * from Zoo";

                //Il SqlDataAdapter si occupa di:
                //Eseguire la query sul database per recuperare i dati.
                //Riempire una struttura dati in memoria, come una DataTable, con i dati restituiti dalla query.
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);  //metto sqlCommand al posto di query, sqlConnection

                //using rilascia le risorse quando non sono piu necessarie (grazie a Dispose() di IDisposable)
                using(adapter)
                {
                    DataTable animalTable = new DataTable();   //creo DataTable vuoto
                   adapter.Fill(animalTable);  //esegue query e popola la DataTable con i dati restituiti
                   //Dopo l'esecuzione di questa riga, la DataTable conterrà tutte le righe della tabella Zoo del database.

                    //la lista mostrerà per ogni elemento il valore della proprietà 'Location' (del db)
                    listZoos.DisplayMemberPath = "Location";
                    // se un elemento della lista viene selezionato restituirà il valore della proprietà 'id'.
                    // (quando un elemento viene selezionato dalla ListBox, la ListBox restituisce l'oggetto associato a quell'elemento. Tuttavia, in molti casi, non vuoi l'intero oggetto, ma solo un valore specifico, come ad esempio l'Id di un oggetto. È qui che entra in gioco la proprietà SelectedValuePath.)
                    //Quindi, se l'utente seleziona "Paris", la proprietà SelectedValue del controllo restituirà 1 (l'ID dello zoo di Parigi).
                    listZoos.SelectedValuePath = "Id";
                    //prendo i dati contenuti nel DataTable in forma di un oggetto di tipo DataView.
                    listZoos.ItemsSource = animalTable.DefaultView;
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowAssociatedAnimals()
        {
            try
            {
                //seleziona tutti gli elementi di Animal e restituisce solo le righe che hanno una corrispondenza in entrambe le tabelle.
                //quando a.Id è = a za.AnimalId (se) where za.ZooId = @ZooId (@ZooId è l'id dell'elemento selezionato)
                string query = "select * from Animal a inner join ZooAnimal " +
                    "za on a.Id = za.AnimalId where za.ZooId = @ZooId";

                //sqlCommand si usa quando ho dei parametri/segnaposto nella query
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // the SqlDataAdapter can be imagined like an Interface to make Tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    //sostituisco il valore di @ZooId con il valore attualmente selezionato nella ListBox listZoos
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);

                    //Which Information of the Table in DataTable should be shown in our ListBox?
                    associatedAnimalsList.DisplayMemberPath = "Name";
                    //Which Value should be delivered, when an Item from our ListBox is selected?
                    associatedAnimalsList.SelectedValuePath = "Id";
                    //The Reference to the Data the ListBox should populate
                    associatedAnimalsList.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void ShowAllAnimals()
        {
            try
            {
                string query = "select * from Animal";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    //questo fa vedere i dati presi nell'animalTable sottoforma di 'Name'
                    listAllAnimals.DisplayMemberPath = "Name";
                    listAllAnimals.SelectedValuePath = "Id";
                    //questo riempie la listBox con i dati dell'animalTable
                    listAllAnimals.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }


        //mi si crea facendo doppio click sulla prima listBox, e si triggera quando ci clicco un elemento
        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("Listzoos was clicked");
            ShowAssociatedAnimals();
        }

        private void listZoos_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
