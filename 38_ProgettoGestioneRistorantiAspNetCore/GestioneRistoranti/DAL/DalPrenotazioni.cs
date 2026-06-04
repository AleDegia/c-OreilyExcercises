using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DALe
{
    public class DalPrenotazioni
    {
        private DbData<Prenotazione> dbData;
        private readonly GestioneRistorantiContext context;
        public DalPrenotazioni() 
        {
            dbData = new DbData<Prenotazione>();
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false)
               .Build();

            var connectionString = configuration.GetConnectionString(
            "GestioneRistorantiConnectionString"
        );

            var options = new DbContextOptionsBuilder<GestioneRistorantiContext>()
       .UseSqlServer(connectionString)
       .Options;

            context = new GestioneRistorantiContext(options);
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
            context.Prenotazioni.Add(prenotazione);
            context.SaveChanges();
        }



        public List<Prenotazione> GetAllPrenotazioniRistorante(int idRistorante)
        {
            return context.Prenotazioni
                      .Where(p => p.IDRistorante == idRistorante)
                      .ToList();
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
            try
            {
                var prenotazioneDb = context.Prenotazioni
                    .FirstOrDefault(p => p.IDPrenotazione == prenotazione.IDPrenotazione);

                if (prenotazioneDb == null)
                    throw new Exception("Prenotazione non trovata");

                prenotazioneDb.IDRistorante = prenotazione.IDRistorante;
                prenotazioneDb.NomeUtente = prenotazione.NomeUtente;
                prenotazioneDb.DataRichiesta = prenotazione.DataRichiesta;
                prenotazioneDb.DataPrenotazione = prenotazione.DataPrenotazione;
                prenotazioneDb.NumPersone = prenotazione.NumPersone;

                var log = new LogPrenotazione
                {
                    IDPrenotazione = prenotazione.IDPrenotazione,
                    DataEvento = DateTime.Now,
                    TipoEvento = "Modifica",
                    DescrizioneEvento = $"Modifica prenotazione per l'utente {prenotazione.NomeUtente}"
                };

                context.LogPrenotazioni.Add(log);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante aggiornamento prenotazione e inserimento log", ex);
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
            //dbData.CancellaEntity(username, "Prenotazioni");
        }
    }
}
