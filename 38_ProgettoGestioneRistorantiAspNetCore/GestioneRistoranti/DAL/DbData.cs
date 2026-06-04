using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace DALe
{
    public class DbData<T> where T : class
    {
        private readonly string connectionString;
        private SqlConnection connectionObj;
        private GestioneRistorantiContext context;
        //public DbData(GestioneRistorantiContext context)
        //{
        //    this.context = context;
        //}

        //public DbData(){ }
        
        public DbData()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            connectionString = configuration.GetConnectionString(
                "GestioneRistorantiConnectionString"
            );

            var options = new DbContextOptionsBuilder<GestioneRistorantiContext>()
       .UseSqlServer(connectionString)
       .Options;

            context = new GestioneRistorantiContext(options);
        }

        //Per DI
        //public DbData(IConfiguration configuration)
        //{
        //    connectionString = configuration.GetConnectionString(
        //        "GestioneRistorantiConnectionString"
        //    );
        //}

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
            //context.Database.OpenConnection();
            //Set<T>() è un metodo di DbContext che restituisce un DbSet<T>, che rappresenta una collezione di entità del tipo T.
            return context.Set<T>().Find(id);  // Find() è un metodo di DbSet<T> che cerca un'entità in base alla chiave primaria (id in questo caso)
        }

        //invece che fare GetRistoranti, GetUtenti, ecc, faccio tutto qui
        public List<object> GetAllEntities()
        {
            return context.Set<T>().Cast<object>().ToList(); // Restituisce tutte le entità del tipo T come una lista di oggetti
        }

        public void AggiungiEntity(T entity)
        {
            try
            {
                if (typeof(T) == typeof(Ristorante) && entity is Ristorante ristorante)
                {
                    context.Add(ristorante);
                    context.SaveChanges();   //esegue effettivamente l'insert
                }
                else if (typeof(T) == typeof(Utente) && entity is Utente utente)
                {

                    context.Add(utente);
                    context.SaveChanges(); 
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
            try
            {
                context.Update(entity);     //prima dovevo creare oggetto del tipo specifico e inserire le proprietà, EF invece vede il tipo da solo e si adatta
                context.SaveChanges();
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

        public void CancellaEntity(T entity)
        {
                try { 
                    context.Remove(entity);
                    context.SaveChanges();
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
            

            //aggiorno lista
            GetAllEntities();
        }

        //prima: Dal crea sql, DbData parla con db e la esegue, ora Dal passa l'entità e DBData esegue con EF 
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


        public DataTable ExecuteCommand(string query, List<SqlParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable result = new DataTable();

            // Utilizza la connessione solo all'interno di questo metodo
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Crea il comando con il tipo di comando desiderato
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = commandType;

                    // Aggiungi i parametri, se esistono
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    // Esegui il comando e carica i dati nel DataTable
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
            }

            return result;
        }


        public Utente GetUtente(string username)
        {
            // La query SQL per cercare un utente in base al nome utente
            //string query = "SELECT TOP 1 * FROM Utenti WHERE UserName = @userName";
                try
                {
                   return context.Find<Utente>(username);  // Find() è un metodo di DbSet<T> che cerca un'entità in base alla chiave primaria (username in questo caso)
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

    }
}
