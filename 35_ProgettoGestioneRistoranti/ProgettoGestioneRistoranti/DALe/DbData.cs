using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DALe
{
    public class DbData<T> where T : class
    {
        private string connectionString;
        private SqlConnection connectionObj;
        public DbData()
        {
            connectionString = ConfigurationManager.ConnectionStrings["GestioneRistorantiConnectionString"].ConnectionString;
        }
        public SqlConnection GetConn()
        {
            if (connectionObj == null)
            {
                connectionObj = new SqlConnection(connectionString);
                connectionObj.Open();
            }
            return connectionObj;
        }

        private readonly Dictionary<Type, string> typeToTableMap = new Dictionary<Type, string>
        {
            { typeof(Ristorante), "AnagraficaRistoranti" },  // Ristorante mappato a AnagraficaRistoranti
            { typeof(Utente), "Utenti" },
            { typeof(Prenotazione), "Prenotazioni" }
        };

        private readonly Dictionary<Type, string> idColumnName = new Dictionary<Type, string>
        {
            { typeof(Ristorante), "IDRistorante" },  // Ristorante mappato a AnagraficaRistoranti
            { typeof(Utente), "UserName" },
            { typeof(Prenotazione), "IDPrenotazione" }
        };


        public string GetTableName(Type type)
        {
            if (typeToTableMap.ContainsKey(type))
            {
                return typeToTableMap[type];
            }
            return null;
        }

        public string GetIdColName(Type type)
        {
            if (idColumnName.ContainsKey(type))
            {
                return idColumnName[type];
            }
            return null;
        }


        public string GetConnectionString()
            { return connectionString; }



        public T GetEntity(int id)
        {
            string tableName = GetTableName(typeof(T));
            string idName = GetIdColName(typeof(T));

            string query = $"SELECT TOP 1 * FROM {tableName} WHERE {idName} = @id";
            T entity = default(T);  // Inizializza l'entità come valore predefinito (perchè??)

            using (SqlConnection openCon = new SqlConnection(connectionString))  // Connessione al DB
            {
                try
                {
                    openCon.Open();  

                    using (SqlCommand command = new SqlCommand(query, openCon))  
                    {
                        command.Parameters.AddWithValue("@id", id);

                        // Eseguo la query
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())  // Se trova un record
                            {
                                if(tableName.Contains("AnagraficaRistoranti"))
                                {
                                    entity = (T)(object) new Ristorante //cast prima a object e poi a T
                                    (
                                        reader.GetInt32(reader.GetOrdinal("IDRistorante")),
                                        reader.GetInt32(reader.GetOrdinal("Tipologia")),
                                        reader.GetString(reader.GetOrdinal("Indirizzo")),
                                        reader.GetString(reader.GetOrdinal("RagioneSociale")),
                                        reader.GetString(reader.GetOrdinal("PartitaIva")),
                                        reader.GetInt32(reader.GetOrdinal("NumPosti")),
                                        reader.GetDecimal(reader.GetOrdinal("PrezzoMedio")),
                                        reader.GetString(reader.GetOrdinal("Telefono")),
                                        reader.GetString(reader.GetOrdinal("Citta"))
                                    );
                                }
                                else if(tableName == "Utenti")
                                {
                                    entity = (T)(object) new Utente
                                    (
                                       reader.GetString(reader.GetOrdinal("UserName")),
                                       reader.GetString(reader.GetOrdinal("Password")),
                                       reader.GetBoolean(reader.GetOrdinal("IsAdministrator")),
                                       reader.GetString(reader.GetOrdinal("Descrizione")),
                                       reader.GetString(reader.GetOrdinal("Email")),
                                       reader.GetString(reader.GetOrdinal("Telefono")),
                                       reader.GetString(reader.GetOrdinal("Citta"))
                                   );
                                }
                                else if(tableName == "Prenotazioni")
                                {
                                    entity = (T)(object) new Prenotazione
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

                }
                catch (SqlException ex)
                {
                    // Gestione specifica degli errori SQL
                    Console.WriteLine("Errore SQL: " + ex.Message);
                    throw new Exception("Errore durante il recupero dell'entità: " + ex.Message, ex) ;  // Rilancia l'eccezione per propagarla ai livelli superiori
                }
                catch (Exception ex)
                {
                    // Gestione di eccezioni generiche
                    Console.WriteLine("Errore generico: " + ex.Message);
                    throw new Exception("Errore durante il recupero dell'entità: " + ex.Message, ex) ;  // Rilancia l'eccezione per propagarla
                }

            }
            return entity;
        }

        public List<object> GetAllEntities()
        {
            string tableName = GetTableName(typeof(T));
            string idName = GetIdColName(typeof(T));
            //var entities = new List<T>();    
            var entities = new List<object>();  // Usa List<object> per contenere qualsiasi tipo
            string query = $"SELECT * FROM {tableName}";

            try
            {
                using (var adapter = new SqlDataAdapter(query, connectionString))
                {
                    var booksTable = new DataTable();
                    adapter.Fill(booksTable);

                    foreach (DataRow row in booksTable.Rows)
                    {
                        if (tableName == "AnagraficaRistoranti")
                        {

                            var ristorante = new Ristorante
                               (
                                   Convert.ToInt32(row["IDRistorante"]),
                                   Convert.ToInt32(row["Tipologia"]),
                                   row["Indirizzo"].ToString(),
                                   row["RagioneSociale"].ToString(),
                                   row["PartitaIva"].ToString(),
                                   Convert.ToInt32(row["NumPosti"]),
                                   Convert.ToDecimal(row["PrezzoMedio"]),
                                   row["Telefono"].ToString(),
                                   row["Citta"].ToString()
                               //)
                               );
                            entities.Add(ristorante);
                        }
                        if (tableName == "Utenti")
                        {
                            var utente = new Utente
                            (
                                row["UserName"].ToString(),
                                row["Password"].ToString(),
                                Convert.ToBoolean(row["IsAdministrator"]),
                                row["Descrizione"].ToString(),
                                row["Email"].ToString(),
                                row["Telefono"].ToString(),
                                row["Citta"].ToString()
                             //   )
                             );
                            entities.Add(utente);
                        }
                        else if(tableName == "Prenotazioni")
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
                            entities.Add(prenotazione);
                        }
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

            return entities;
        }

        public void AggiungiEntity(T entity)
        {
            try
            {
                using (SqlConnection openCon = new SqlConnection(connectionString))
                {
                    openCon.Open(); //apro conn una sola volta
                    string queryRistorante = "INSERT into AnagraficaRistoranti (Tipologia, Indirizzo, RagioneSociale, PartitaIva, NumPosti, PrezzoMedio, Telefono, Citta) VALUES (@Tipologia, @Indirizzo,@RagioneSociale, @PartitaIva, @NumPosti, @PrezzoMedio, @Telefono, @Citta)";
                    string queryUtente = "INSERT into Utenti (Username, Password, IsAdministrator, Descrizione, Email, Telefono, Citta) VALUES (@UserName, @Password, @IsAdministrator, @Descrizione, @Email, @Telefono, @Citta)";

                    if (typeof(T) == typeof(Ristorante) && entity is Ristorante ristorante)
                    {

                        using (SqlCommand querySaveStaff = new SqlCommand(queryRistorante))
                        {
                            querySaveStaff.Connection = openCon;

                            querySaveStaff.Parameters.AddWithValue("@Tipologia", ristorante.GetTipologia());
                            querySaveStaff.Parameters.AddWithValue("@Indirizzo", ristorante.GetIndirizzo());
                            querySaveStaff.Parameters.AddWithValue("@RagioneSociale", ristorante.GetRagioneSociale());
                            querySaveStaff.Parameters.AddWithValue("@PartitaIva", ristorante.GetPartitaIva());
                            querySaveStaff.Parameters.AddWithValue("@NumPosti", ristorante.GetNumPosti());
                            querySaveStaff.Parameters.AddWithValue("@PrezzoMedio", ristorante.GetPrezzoMedio());
                            querySaveStaff.Parameters.AddWithValue("@Telefono", ristorante.GetTelefono());
                            querySaveStaff.Parameters.AddWithValue("@Citta", ristorante.GetCitta());

                            querySaveStaff.ExecuteNonQuery();

                        }
                    }
                    else if (typeof(T) == typeof(Utente) && entity is Utente utente)
                    {

                        using (SqlCommand querySaveStaff = new SqlCommand(queryUtente))
                        {
                            querySaveStaff.Connection = openCon;

                            querySaveStaff.Parameters.AddWithValue("@UserName", utente.GetUserName());
                            querySaveStaff.Parameters.AddWithValue("@Password", utente.GetPassword());
                            querySaveStaff.Parameters.AddWithValue("@IsAdministrator", utente.GetIsAdministrator());
                            querySaveStaff.Parameters.AddWithValue("@Descrizione", utente.GetDescrizione());
                            querySaveStaff.Parameters.AddWithValue("@Email", utente.GetEmail());
                            querySaveStaff.Parameters.AddWithValue("@Telefono", utente.GetTelefono());
                            querySaveStaff.Parameters.AddWithValue("@Citta", utente.GetCitta());

                            querySaveStaff.ExecuteNonQuery();
                        }
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

        public void ModificaEntity(T entity)
        {
            string queryRistorante = $"UPDATE AnagraficaRistoranti SET Tipologia = @Tipologia, Indirizzo = @Indirizzo,  RagioneSociale = @RagioneSociale,  PartitaIva = @PartitaIva,  NumPosti = @NumPosti, PrezzoMedio = @PrezzoMedio, Telefono = @Telefono, Citta = @Citta WHERE IDRistorante = @IDRistorante";
            string queryUtente = $"UPDATE Utenti SET UserName = @Username, Password = @Password, IsAdministrator = @IsAdministrator,  Descrizione = @Descrizione,  Email = @Email,  Telefono = @Telefono, Citta = @Citta WHERE Username = @Username";

            using (SqlConnection openCon = new SqlConnection(connectionString))  // creo ogg per connettermi al db
            {
                try
                {
                    openCon.Open();

                    if (entity is Ristorante ristorante)
                    {

                        //UPDATE table1 SET table1.column = table2.expression1 FROM table1 [WHERE conditions];
                        using (SqlCommand cmd = new SqlCommand(queryRistorante, openCon))  // Prepara la query
                        {
                            cmd.Parameters.AddWithValue("@IDRistorante", ristorante.GetIDRistorante());
                            cmd.Parameters.AddWithValue("@Tipologia", ristorante.GetTipologia());
                            cmd.Parameters.AddWithValue("@Indirizzo", ristorante.GetIndirizzo());
                            cmd.Parameters.AddWithValue("@RagioneSociale", ristorante.GetRagioneSociale());
                            cmd.Parameters.AddWithValue("@PartitaIva", ristorante.GetPartitaIva());
                            cmd.Parameters.AddWithValue("@NumPosti", ristorante.GetNumPosti());
                            cmd.Parameters.AddWithValue("@PrezzoMedio", ristorante.GetPrezzoMedio());
                            cmd.Parameters.AddWithValue("@Telefono", ristorante.GetCitta());
                            cmd.Parameters.AddWithValue("@Citta", ristorante.GetTelefono());

                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Ristorante Aggiornato!");
                        }
                    }
                    else if(entity is Utente utente)
                    {
                        using (SqlCommand cmd = new SqlCommand(queryUtente, openCon))  // Prepara la query
                        {
                            cmd.Parameters.AddWithValue("@UserName", utente.GetUserName());
                            cmd.Parameters.AddWithValue("@Password", utente.GetPassword());
                            cmd.Parameters.AddWithValue("@IsAdministrator", utente.GetIsAdministrator());
                            cmd.Parameters.AddWithValue("@Descrizione", utente.GetDescrizione());
                            cmd.Parameters.AddWithValue("@Email", utente.GetEmail());
                            cmd.Parameters.AddWithValue("@Telefono", utente.GetCitta());
                            cmd.Parameters.AddWithValue("@Citta", utente.GetTelefono());

                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Utente Aggiornato!");
                        }
                    }
                    else if(entity is Prenotazione)
                    {

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
                    throw new Exception("Si è verificato un errore durante l'inserimento dell'entità", ex);  // Rilancio dell'eccezione
                }
            }
        }

        public void CancellaEntity(string id, string nomeTabella)
        {
            string query = $"DELETE FROM AnagraficaRistoranti WHERE IDRistorante = @id";
            string queryUtente = $"DELETE FROM Utenti WHERE UserName = @username";
            string queryPrenotazione = $"DELETE FROM Prenotazioni WHERE NomeUtente = @username";
            using (SqlConnection openCon = new SqlConnection(connectionString))
            {
                try
                {
                    openCon.Open();
                    if (nomeTabella == "AnagraficaRistoranti")
                    {
                        using (SqlCommand cmd = new SqlCommand(query, openCon))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (nomeTabella == "Utenti")
                    {
                        using (SqlCommand cmd = new SqlCommand(queryUtente, openCon))
                        {
                            cmd.Parameters.AddWithValue("@username", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (nomeTabella == "Prenotazioni")
                    {
                        using (SqlCommand cmd = new SqlCommand(queryPrenotazione, openCon))
                        {
                            cmd.Parameters.AddWithValue("@username", id);
                            cmd.ExecuteNonQuery();
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

            //aggiorno lista
            GetAllEntities();
        }

        public DataTable ExecuteCommand(string query, List<SqlParameter> parameters)
        {
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;

                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    // Esegui il comando SELECT
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Carica i dati nel DataTable
                        result.Load(reader);
                    }
                }
            }
            return result;
        }



        public Utente GetUtente(string username)
        {
            // La query SQL per cercare un utente in base al nome utente
            string query = "SELECT TOP 1 * FROM Utenti WHERE UserName = @userName";
            Utente utente = null;

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
                                // Crea l'oggetto Utente con i dati letti dal database
                                utente = new Utente
                                (
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetBoolean(reader.GetOrdinal("IsAdministrator")),
                                    reader.GetString(reader.GetOrdinal("Descrizione")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Telefono")),
                                    reader.GetString(reader.GetOrdinal("Citta"))
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

            // Ritorna l'utente trovato, oppure null se non trovato
            return utente;
        }

    }
}
