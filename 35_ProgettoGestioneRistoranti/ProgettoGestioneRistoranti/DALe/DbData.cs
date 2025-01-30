using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DALe
{
    public class DbData<T> where T : class
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["GestioneRistorantiConnectionString"].ConnectionString;
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
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

            using (var adapter = new SqlDataAdapter(query, connectionString))
            {
                var booksTable = new DataTable();
                adapter.Fill(booksTable);

                foreach (DataRow row in booksTable.Rows)
                {
                    if(tableName == "AnagraficaRistoranti")
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
                    if(tableName == "Utenti")
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
                    
                }
            }

            return entities;
        }

        public void AggiungiEntity(T entity)
        {
            using (SqlConnection openCon = new SqlConnection(connectionString))
            {

                string queryRistorante = "INSERT into AnagraficaRistoranti (Tipologia, Indirizzo, RagioneSociale, PartitaIva, NumPosti, PrezzoMedio, Telefono, Citta) VALUES (@Tipologia, @Indirizzo,@RagioneSociale, @PartitaIva, @NumPosti, @PrezzoMedio, @Telefono, @Citta)";
                string queryUtente = "INSERT into Utenti (Username, Password, IsAdministrator, Descrizione, Email, Telefono, Citta) VALUES (@UserName, @Password, @IsAdministrator, @Descrizione, @Email, @Telefono, @Citta)";

                if (typeof(T) == typeof(Ristorante) && entity is Ristorante ristorante)
                {

                    using (SqlCommand querySaveStaff = new SqlCommand(queryRistorante))
                    {
                        querySaveStaff.Connection = openCon;
                        openCon.Open();

                        querySaveStaff.Parameters.AddWithValue("@Tipologia", ristorante.GetTipologia());
                        querySaveStaff.Parameters.AddWithValue("@Indirizzo", ristorante.GetIndirizzo());
                        querySaveStaff.Parameters.AddWithValue("@RagioneSociale", ristorante.GetRagioneSociale());
                        querySaveStaff.Parameters.AddWithValue("@PartitaIva", ristorante.GetPartitaIva());
                        querySaveStaff.Parameters.AddWithValue("@NumPosti", ristorante.GetNumPosti());
                        querySaveStaff.Parameters.AddWithValue("@PrezzoMedio", ristorante.GetPrezzoMedio());
                        querySaveStaff.Parameters.AddWithValue("@Telefono", ristorante.GetTelefono());
                        querySaveStaff.Parameters.AddWithValue("@Citta", ristorante.GetCitta());

                        try
                        {
                            querySaveStaff.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Hai già acquistato questo libro");
                            //MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (typeof(T) == typeof(Utente) && entity is Utente utente)
                {

                    using (SqlCommand querySaveStaff = new SqlCommand(queryUtente))
                    {
                        querySaveStaff.Connection = openCon;
                        openCon.Open();

                        querySaveStaff.Parameters.AddWithValue("@UserName", utente.GetUserName());
                        querySaveStaff.Parameters.AddWithValue("@Password", utente.GetPassword());
                        querySaveStaff.Parameters.AddWithValue("@IsAdministrator", utente.GetIsAdministrator());
                        querySaveStaff.Parameters.AddWithValue("@Descrizione", utente.GetDescrizione());
                        querySaveStaff.Parameters.AddWithValue("@Email", utente.GetEmail());
                        querySaveStaff.Parameters.AddWithValue("@Telefono", utente.GetTelefono());
                        querySaveStaff.Parameters.AddWithValue("@Citta", utente.GetCitta());

                        try
                        {
                            querySaveStaff.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Hai già acquistato questo libro");
                           // MessageBox.Show(ex.Message);
                        }
                    }
                }

            }
        }

        public void ModificaEntity(T entity)
        {
            string queryRistorante = $"UPDATE AnagraficaRistoranti SET Tipologia = @Tipologia, Indirizzo = @Indirizzo,  RagioneSociale = @RagioneSociale,  PartitaIva = @PartitaIva,  NumPosti = @NumPosti, PrezzoMedio = @PrezzoMedio, Telefono = @Telefono, Citta = @Citta WHERE IDRistorante = @IDRistorante";
            string queryUtente = $"UPDATE Utenti SET UserName = @Username, Password = @Password, IsAdministrator = @IsAdministrator,  Descrizione = @Descrizione,  Email = @Email,  Telefono = @Telefono, Citta = @Citta WHERE Username = @Username";

            using (SqlConnection openCon = new SqlConnection(connectionString))  // Connetto al DB
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
                catch (Exception ex)
                {
                    //MessageBox.Show("qualcosa non ha funzionato");
                    //MessageBox.Show(ex.ToString());
                }
            }
        }

        public void CancellaEntity(string id, string nomeTabella)
        {
            string query = $"DELETE FROM AnagraficaRistoranti WHERE IDRistorante = @id";
            string queryUtente = $"DELETE FROM Utenti WHERE UserName = @username";
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
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("qualcosa non ha funzionato");
                    Console.WriteLine(ex.ToString());
                }
            }

            //aggiorno lista
            GetAllEntities();
        }

        public List<Prenotazione> GetAllPrenotazioni(int idRistorante)
        {
           
            string query = $"SELECT * FROM Prenotazioni WHERE IDRistorante = {idRistorante}";
            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            //MessageBox.Show(idRistorante.ToString());

            using (var adapter = new SqlDataAdapter(query, connectionString))
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
            return prenotazioni;
        }


        public void AggiungiPrenotazione(Prenotazione prenotazione)
        {
            using (SqlConnection openCon = new SqlConnection(connectionString))
            {

                string query = "INSERT into Prenotazioni (IDRistorante, NomeUtente, DataRichiesta, DataPrenotazione, NumPersone) VALUES (@IDRistorante,@NomeUtente, @DataRichiesta, @DataPrenotazione, @NumPersone)";

                using (SqlCommand querySaveStaff = new SqlCommand(query))
                {
                    querySaveStaff.Connection = openCon;
                    openCon.Open();

                    querySaveStaff.Parameters.AddWithValue("@IDRistorante", prenotazione.IDRistorante);
                    querySaveStaff.Parameters.AddWithValue("@NomeUtente", prenotazione.NomeUtente);
                    querySaveStaff.Parameters.AddWithValue("@DataRichiesta", prenotazione.DataRichiesta);
                    querySaveStaff.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                    querySaveStaff.Parameters.AddWithValue("@NumPersone", prenotazione.NumPersone);

                    try
                    {
                        querySaveStaff.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
