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
            dbData.AggiungiPrenotazione(prenotazione);
        }

        public List<Prenotazione> GetAllPrenotazioni(int idRistorante)
        {
            List<Prenotazione> prenotazioni = dbData.GetAllPrenotazioni(idRistorante);
            return prenotazioni;
        }

        public List<Prenotazione> GetPrenotazioniPerData(DateTime data)
        {
            List<Prenotazione> prenotazioni = dbData.GetPrenotazioniPerData(data);
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
            try
            {
                dbData.AggiornaPrenotazioneELog(prenotazione);
            }
            catch (Exception ex)
            {
                throw; //rilancio eccezione
            }
        }

        public Prenotazione GetPrenotazione(string username)
        {
            string b = username;
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
