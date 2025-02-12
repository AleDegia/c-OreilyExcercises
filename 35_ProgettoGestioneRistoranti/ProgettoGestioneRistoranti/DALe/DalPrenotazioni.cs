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
            try
            {
                string query = "INSERT INTO Prenotazioni (IDRistorante, NomeUtente, DataRichiesta, DataPrenotazione, NumPersone) " +
                               "VALUES (@IDRistorante, @NomeUtente, @DataRichiesta, @DataPrenotazione, @NumPersone)";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IDRistorante", SqlDbType.Int) { Value = prenotazione.IDRistorante },
                    new SqlParameter("@NomeUtente", SqlDbType.VarChar) { Value = prenotazione.NomeUtente },
                    new SqlParameter("@DataRichiesta", SqlDbType.DateTime) { Value = prenotazione.DataRichiesta },
                    new SqlParameter("@DataPrenotazione", SqlDbType.DateTime) { Value = prenotazione.DataPrenotazione },
                    new SqlParameter("@NumPersone", SqlDbType.Int) { Value = prenotazione.NumPersone }
                };

                // Usa ExecuteCommand per eseguire l'inserimento
                dbData.ExecuteCommand(query, parameters);

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
                throw new Exception("Si è verificato un errore durante l'esecuzione della prenotazione", ex);  // Rilancio dell'eccezione
            }
        }



        public List<Prenotazione> GetAllPrenotazioniRistorante(int idRistorante)
        {
            string query = "SELECT * FROM Prenotazioni WHERE IDRistorante = @IDRistorante";
            List<Prenotazione> prenotazioni = new List<Prenotazione>();

            // Parametri per la query
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IDRistorante", SqlDbType.Int) { Value = idRistorante }
            };

            try
            {
                DataTable tablePrenotazioni = dbData.ExecuteCommand(query, parameters);

                // Creazione della lista delle prenotazioni
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
                throw new Exception("Si è verificato un errore durante il recupero delle prenotazioni", ex);  // Rilancio dell'eccezione
            }

            return prenotazioni;
        }


        public List<Prenotazione> GetPrenotazioniPerData(DateTime data)
        {
            string query = "SELECT * FROM Prenotazioni WHERE DataPrenotazione = @DataPrenotazione";
            List<Prenotazione> prenotazioni = new List<Prenotazione>();

            // Parametri per la query
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@DataPrenotazione", SqlDbType.DateTime) { Value = data.Date }  // Rimuove l'orario dalla data
            };

            try
            {
                // Usa ExecuteCommand per ottenere i dati
                DataTable tablePrenotazioni = dbData.ExecuteCommand(query, parameters);

                // Elaborazione dei dati e creazione della lista delle prenotazioni
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
            Prenotazione prenotazione = null;

            // Parametro per la query
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@userName", SqlDbType.NVarChar) { Value = username }
            };

            try
            {
                DataTable tablePrenotazioni = dbData.ExecuteCommand(query, parameters);

                // Se è stato trovato un record, crea la prenotazione
                if (tablePrenotazioni.Rows.Count > 0)
                {
                    var row = tablePrenotazioni.Rows[0];
                    prenotazione = new Prenotazione
                    (
                        Convert.ToInt32(row["IDPrenotazione"]),
                        Convert.ToInt32(row["IDRistorante"]),
                        row["NomeUtente"].ToString(),
                        Convert.ToDateTime(row["DataRichiesta"]),
                        Convert.ToDateTime(row["DataPrenotazione"]),
                        Convert.ToInt32(row["NumPersone"])
                    );
                }
            }
            catch (SqlException sqlEx)
            {
                // Gestione degli errori SQL
                Console.WriteLine("Errore SQL: " + sqlEx.Message);
                throw new Exception("Errore durante il recupero della prenotazione", sqlEx);  // Rilancia l'eccezione
            }
            catch (Exception ex)
            {
                // Gestione degli errori generici
                Console.WriteLine("Errore generico: " + ex.Message);
                throw new Exception("Errore durante il recupero della prenotazione", ex);  // Rilancia l'eccezione
            }

            return prenotazione;
        }


        public void CancellaPrenotazione(string username)
        {
            dbData.CancellaEntity(username, "Prenotazioni");
        }
    }
}
