using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Models;

namespace DALe
{
    public class DalPrenotazioni
    {
        private DbData<Prenotazione> dbData;
        public DalPrenotazioni() 
        {
            dbData = new DbData<Prenotazione>();
        }

        public List<Prenotazione> GetAllPrenotazioni()
        {
            object preno =  dbData.GetAllEntities();

            // Verifica che preno sia effettivamente una lista di oggetti
            List<Object> listaObject = preno as List<Object>;

            if (listaObject != null)
            {
                // Fai il cast a List<Prenotazione> usando LINQ
                List<Prenotazione> prenotazioni = listaObject.Cast<Prenotazione>().ToList();
                return prenotazioni;
            }
            else
            {
                // Se non è possibile fare il cast, gestisci l'errore
                throw new InvalidCastException("Impossibile fare il cast della lista");
            }
        }
        
        public void AggiungiPrenotazione(Prenotazione prenotazione)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["GestioneRistorantiConnectionString"].ConnectionString;
            try
            {
                string query = "INSERT into Prenotazioni (IDRistorante, NomeUtente, DataRichiesta, DataPrenotazione, NumPersone) VALUES (@IDRistorante,@NomeUtente, @DataRichiesta, @DataPrenotazione, @NumPersone)";
                //List<SqlParameter> parameters = new List<SqlParameter>();

                //dbData.ExecuteCommand(query, parameters);

                using (var connection = dbData.GetConn())
                {

                    using (SqlCommand querySaveStaff = new SqlCommand(query))
                    {
                        querySaveStaff.Connection = connection;
                        //openCon.Open();

                        querySaveStaff.Parameters.AddWithValue("@IDRistorante", prenotazione.IDRistorante);
                        querySaveStaff.Parameters.AddWithValue("@NomeUtente", prenotazione.NomeUtente);
                        querySaveStaff.Parameters.AddWithValue("@DataRichiesta", prenotazione.DataRichiesta);
                        querySaveStaff.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                        querySaveStaff.Parameters.AddWithValue("@NumPersone", prenotazione.NumPersone);

                        querySaveStaff.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                 // Gestione specifica degli errori SQL
                 Console.WriteLine("Errore SQL: " + sqlEx.Message);
                 throw new Exception("Errore durante l'esecuzione della query nel database", sqlEx);  // Rilancio dell'eccezione
            }
            catch (Exception ex)
            {
                 // Gestione di altre eccezioni
                 Console.WriteLine("Errore generico: " + ex.Message);
                 throw new Exception("Si è verificato un errore durante il recupero delle entità", ex);  // Rilancio dell'eccezione
            }
            
        }
        

        public List<Prenotazione> GetAllPrenotazioniRistorante(int idRistorante)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["GestioneRistorantiConnectionString"].ConnectionString;
            string query = $"SELECT * FROM Prenotazioni WHERE IDRistorante = {idRistorante}";
            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            //MessageBox.Show(idRistorante.ToString());

            try
            {
                var connection = dbData.GetConn();
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var tablePrenotazioni = new DataTable();
                    adapter.Fill(tablePrenotazioni);

                    foreach (DataRow row in tablePrenotazioni.Rows)
                    {
                        var prenotazione = new Prenotazione
                           (
                               Convert.ToInt32(row["IDPrenotazione"]),
                               Convert.ToInt32(row["IDRistorante"]),
                               row["NomeUtente"].ToString(),
                               Convert.ToDateTime(row["DataRichiesta"]),
                               Convert.ToDateTime(row["DataPrenotazione"]),
                               Convert.ToInt32(row["NumPersone"])

                           );
                        prenotazioni.Add(prenotazione);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Gestione specifica degli errori SQL
                Console.WriteLine("Errore SQL: " + sqlEx.Message);
                throw new Exception("Errore durante l'esecuzione della query nel database", sqlEx);  // Rilancio dell'eccezione
            }
            catch (Exception ex)
            {
                // Gestione di altre eccezioni
                Console.WriteLine("Errore generico: " + ex.Message);
                throw new Exception("Si è verificato un errore durante il recupero delle entità", ex);  // Rilancio dell'eccezione
            }
            return prenotazioni;
        }

        public List<Prenotazione> GetPrenotazioniPerData(DateTime data)
        {
            string query = "SELECT * FROM Prenotazioni WHERE DataPrenotazione = @DataPrenotazione";
            List<Prenotazione> prenotazioni = new List<Prenotazione>();

            try
            {
                //string connectionString = ConfigurationManager.ConnectionStrings["GestioneRistorantiConnectionString"].ConnectionString;
                using (var connection = dbData.GetConn())   //prendo connessione aperta dal dbdata
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Imposta il parametro con il valore della data
                        command.Parameters.AddWithValue("@DataPrenotazione", data.Date); // Usa data.Date per rimuovere l'orario

                        using (var adapter = new SqlDataAdapter(command))
                        {
                            var tablePrenotazioni = new DataTable();
                            adapter.Fill(tablePrenotazioni);

                            foreach (DataRow row in tablePrenotazioni.Rows)
                            {
                                var prenotazione = new Prenotazione
                                (
                                    Convert.ToInt32(row["IDPrenotazione"]),
                                    Convert.ToInt32(row["IDRistorante"]),
                                    row["NomeUtente"].ToString(),
                                    Convert.ToDateTime(row["DataRichiesta"]),
                                    Convert.ToDateTime(row["DataPrenotazione"]),
                                    Convert.ToInt32(row["NumPersone"])
                                );
                                prenotazioni.Add(prenotazione);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Gestione degli errori SQL
                Console.WriteLine("Errore SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Gestione di altre eccezioni
                Console.WriteLine("Errore generico: " + ex.Message);
            }

            return prenotazioni;
        }

        public List<Prenotazione> GetPrenotazioni()
        {
            List<object> entities = dbData.GetAllEntities();
            List<Prenotazione> prenotazioni = entities.OfType<Prenotazione>().ToList();
            return prenotazioni;
        }

        public void AggiornaPrenotazioneELog(Prenotazione prenotazione)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["GestioneRistorantiConnectionString"].ConnectionString;
            string queryPrenotazione = @"UPDATE Prenotazioni 
                                 SET IDRistorante = @IDRistorante,  
                                     NomeUtente = @NomeUtente,  
                                     DataRichiesta = @DataRichiesta,  
                                     DataPrenotazione = @DataPrenotazione, 
                                     NumPersone = @NumPersone 
                                 WHERE IDPrenotazione = @IDPrenotazione";

            // Modifica: Query INSERT per LogPrenotazioni
            string queryLog = @"INSERT INTO LogPrenotazioni 
                        (IDPrenotazione, DataEvento, TipoEvento, DescrizioneEvento) 
                        VALUES 
                        (@IDPrenotazione, @DataEvento, @TipoEvento, @DescrizioneEvento)";

            using (var connection = dbData.GetConn())
            {
                //connection.Open();

                // Inizializzo la transazione
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Creo il comando SQL associato alla transazione
                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    //aggiornamento per la prenotazione
                    command.CommandText = queryPrenotazione;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@IDPrenotazione", prenotazione.IDPrenotazione);
                    command.Parameters.AddWithValue("@IDRistorante", prenotazione.IDRistorante);
                    command.Parameters.AddWithValue("@NomeUtente", prenotazione.NomeUtente);
                    command.Parameters.AddWithValue("@DataRichiesta", prenotazione.DataRichiesta);
                    command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                    command.Parameters.AddWithValue("@NumPersone", prenotazione.NumPersone);
                    command.ExecuteNonQuery();

                    //inserimento per LogPrenotazione
                    command.CommandText = queryLog;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@IDPrenotazione", /*"ciao"*/prenotazione.IDPrenotazione); // ID della prenotazione
                    command.Parameters.AddWithValue("@DataEvento", DateTime.Now);  // Data dell'evento
                    command.Parameters.AddWithValue("@TipoEvento", "Modifica");  // Tipo di evento
                    command.Parameters.AddWithValue("@DescrizioneEvento", $"Modifica prenotazione per l'utente {prenotazione.NomeUtente}"); // Descrizione evento
                    command.ExecuteNonQuery();

                    // Se entrambe le query sono andate a buon fine faccio il commit
                    sqlTran.Commit();
                    Console.WriteLine("Prenotazione e Log aggiornati con successo.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    try
                    {
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine($"Errore rollback: {exRollback.Message}");
                        throw;
                    }
                    throw;  // Rilancia l'eccezione originale
                }
            }
        }

        public Prenotazione GetPrenotazione(string username)
        {
           
            string query = "SELECT TOP 1 * FROM Prenotazioni WHERE NomeUtente = @userName";
            string connectionString = ConfigurationManager.ConnectionStrings["GestioneRistorantiConnectionString"].ConnectionString;
            Prenotazione prenotazione = null;
            using (SqlConnection openCon = new SqlConnection(connectionString))  // Connessione al DB
            {
                try
                {
                    openCon.Open();  // Apre la connessione

                    using (SqlCommand command = new SqlCommand(query, openCon))  // Crea il comando
                    {
                        // Aggiungi il parametro per evitare attacchi di SQL injection
                        command.Parameters.AddWithValue("@userName", username);

                        using (SqlDataReader reader = command.ExecuteReader())  // Esegui la query
                        {
                            if (reader.Read())  // Se un record è stato trovato
                            {
                                prenotazione = new Prenotazione
                                (
                                    reader.GetInt32(reader.GetOrdinal("IDPrenotazione")),
                                    reader.GetInt32(reader.GetOrdinal("IDRistorante")),
                                    reader.GetString(reader.GetOrdinal("NomeUtente")),
                                    reader.GetDateTime(reader.GetOrdinal("DataRichiesta")),
                                    reader.GetDateTime(reader.GetOrdinal("DataPrenotazione")),
                                    reader.GetInt32(reader.GetOrdinal("NumPersone"))
                                );
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Gestione degli errori SQL
                    Console.WriteLine("Errore SQL: " + ex.Message);
                    throw new Exception("Errore durante il recupero dell'utente", ex);  // Rilancia l'eccezione
                }
                catch (Exception ex)
                {
                    // Gestione degli errori generici
                    Console.WriteLine("Errore generico: " + ex.Message);
                    throw new Exception("Errore durante il recupero dell'utente", ex);  // Rilancia l'eccezione
                }
            }
            return prenotazione;
        }

        public void CancellaPrenotazione(string username)
        {
            dbData.CancellaEntity(username, "Prenotazioni");
        }
    }
}
