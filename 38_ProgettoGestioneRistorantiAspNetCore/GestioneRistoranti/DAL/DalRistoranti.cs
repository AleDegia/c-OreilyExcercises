using DALe;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;


namespace Dal
{
    public class DalRistoranti
    {

        private DbData<Ristorante> dbData;
        private readonly GestioneRistorantiContext context;

        public DalRistoranti()
        {
            dbData = new DbData<Ristorante>();
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

        Dictionary<string, int> tipologieRistorante = new Dictionary<string, int>()
        {
            { "italiano", 1 },
            { "giapponese", 2 },
            { "cinese", 3 },
            { "messicano", 4 },
            { "fastFood", 5 }
        };


        public Ristorante GetRistorante(int id)
        {
            //per prendere la propagazione dell'errore da dbData
            try
            {
                return dbData.GetEntity(id);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Errore durante il recupero del ristorante: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public List<Ristorante> GetRistoranti()
        {
            try
            {
                // Ottengo la lista generica
                List<object> entities = dbData.GetAllEntities();
                // Filtro e casto ogni elemento della lista a Ristorante
                List<Ristorante> ristoranti = entities.OfType<Ristorante>().ToList();
                return ristoranti;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Errore durante il recupero dei ristoranti: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public void AggiungiRistorante(Ristorante ristorante)
        {
            try
            {
                dbData.AggiungiEntity(ristorante);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Errore durante l'inserimento del ristorante: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public void ModificaRistorante(Ristorante ristorante)
        {
            dbData.ModificaEntity(ristorante);
        }

        public void CancellaRistorante(Ristorante ristorante)
        {
            dbData.CancellaEntity(ristorante);
        }

        //da far fare adl dbData
        public List<Ristorante> GetRistorantiFiltrati(string filtro, string inputUtente)
        {
            //recupero tutti i ristoranti
            IQueryable<Ristorante> query = context.Ristoranti;

            switch (filtro)
            {
                case "Tipologia":
                    int tipologia = tipologieRistorante[inputUtente.ToLower()];
                    query = query.Where(r => r.Tipologia == tipologia); //filtro per tipologia
                    break;

                case "Citta":
                    query = query.Where(r => r.Citta == inputUtente);
                    break;

                case "Prezzo":
                    string prezzo = inputUtente.Replace(",", ".");

                    decimal prezzoMedio = Convert.ToDecimal(
                        prezzo,
                        CultureInfo.InvariantCulture
                    );

                    query = query.Where(r => r.PrezzoMedio == prezzoMedio);
                    break;

                default:
                    return new List<Ristorante>();
            }

            return query.ToList();
        }


        public DataTable GetDatiElencoRistoranti()
        {
            var result =
                from r in context.Ristoranti
                join t in context.Tipologie
                    on r.Tipologia equals t.Tipologia into tipologie
                from t in tipologie.DefaultIfEmpty()
                select new      //faccio new perche devo fare nuovo ogg con i campi che mi servono, non posso fare select r perche mi da tutti i campi di ristorante senza il nome della tipologia, invece con new posso fare un oggetto anonimo con i campi di ristorante e aggiungere il campo della tipologia
                {
                    r.IDRistorante,
                    r.Tipologia,
                    r.NumPosti,
                    r.PartitaIva,
                    r.RagioneSociale,
                    r.Indirizzo,
                    r.Citta,
                    r.Telefono,
                    TipoRistorante = t != null ? t.Descrizione : null
                };

            DataTable dt = new DataTable();

            dt.Columns.Add("IdRistorante", typeof(int));
            dt.Columns.Add("Tipologia", typeof(string));
            dt.Columns.Add("NumPosti", typeof(int));
            dt.Columns.Add("PartitaIva", typeof(string));
            dt.Columns.Add("RagioneSociale", typeof(string));
            dt.Columns.Add("Indirizzo", typeof(string));
            dt.Columns.Add("Citta", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("TipoRistorante", typeof(string));

            foreach (var item in result.ToList())
            {
                dt.Rows.Add(
                    item.IDRistorante,
                    item.Tipologia,
                    item.NumPosti,
                    item.PartitaIva,
                    item.TipoRistorante,
                    item.RagioneSociale,
                    item.Indirizzo,
                    item.Citta,
                    item.Telefono
                );
            }

            return dt;
        }


        public Dictionary<string, decimal> GetGuadagniPerMese2024()
        {
            //converte in mese e anno, Calcola il guadagno totale per ogni prenotazione se la data è nel 2024
            string query = @"
                SELECT 
                    FORMAT(P.DataPrenotazione, 'MMMM yyyy') AS MeseAnno, 
                    SUM(R.PrezzoMedio * P.NumPersone) AS GuadagnoMensile
                FROM 
                    Prenotazioni P
                JOIN 
                    AnagraficaRistoranti R ON P.IDRistorante = R.IDRistorante
                WHERE 
                    YEAR(P.DataPrenotazione) = 2024
                GROUP BY 
                    FORMAT(P.DataPrenotazione, 'yyyyMM'), 
                    FORMAT(P.DataPrenotazione, 'MMMM yyyy')
                ORDER BY 
                     FORMAT(P.DataPrenotazione, 'yyyyMM');
            ";

            List<SqlParameter> parameters = new List<SqlParameter>(); // Nessun parametro aggiuntivo necessario in questo caso
            DataTable resultTable = dbData.ExecuteCommand(query, parameters);

            // Crea il dizionario per i guadagni per mese
            Dictionary<string, decimal> guadagniPerMese = new Dictionary<string, decimal>();

            foreach (DataRow row in resultTable.Rows)
            {
                string meseAnno = row["MeseAnno"].ToString();
                decimal guadagno = Convert.ToDecimal(row["GuadagnoMensile"]);

                guadagniPerMese[meseAnno] = guadagno;
            }

            return guadagniPerMese;
        }



        public Dictionary<string, decimal> GetGuadagniPerMeseRistorante(int id)
        {
            //converte in mese e anno, Calcola il guadagno totale per ogni prenotazione se la data è nel 2024
            string query = @"
                SELECT 
                    FORMAT(P.DataPrenotazione, 'MMMM yyyy') AS MeseAnno, 
                    SUM(R.PrezzoMedio * P.NumPersone) AS GuadagnoMensile
                FROM 
                    Prenotazioni P
                JOIN 
                    AnagraficaRistoranti R ON P.IDRistorante = R.IDRistorante
                WHERE 
                    YEAR(P.DataPrenotazione) = 2024 AND R.IDRistorante = @id
                GROUP BY 
                    FORMAT(P.DataPrenotazione, 'MMMM yyyy')
                ORDER BY 
                    MeseAnno;
            ";

            List<SqlParameter> parameters = new List<SqlParameter>(); // Nessun parametro aggiuntivo necessario in questo caso
            parameters.Add(new SqlParameter("@id", SqlDbType.Int)
             { 
                Value = Convert.ToInt32(id) 
            }
            );
            DataTable resultTable = dbData.ExecuteCommand(query, parameters);

            // Crea il dizionario per i guadagni per mese
            Dictionary<string, decimal> guadagniPerMese = new Dictionary<string, decimal>();

            foreach (DataRow row in resultTable.Rows)
            {
                string meseAnno = row["MeseAnno"].ToString();
                decimal guadagno = Convert.ToDecimal(row["GuadagnoMensile"]);

                guadagniPerMese[meseAnno] = guadagno;
            }

            return guadagniPerMese;
        }
    }
}
