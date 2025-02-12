using DALe;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Linq.Expressions;


namespace Dal
{
    public class DalRistoranti
    {

        private DbData<Ristorante> dbData;

        public DalRistoranti()
        {
            dbData = new DbData<Ristorante>();
        }

       
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

        public void CancellaRistorante(string id, string nomeTabella)
        { 
            dbData.CancellaEntity(id, nomeTabella);
        }

        //da far fare adl dbData
        public List<Ristorante> GetRistorantiFiltrati(string filtro, string inputUtente)
        {
            string query = string.Empty;
            List<SqlParameter> parameters = new List<SqlParameter>();

            switch (filtro)
            {
                case "Tipologia":
                    query = "SELECT * FROM AnagraficaRistoranti WHERE Tipologia = @Tipologia";
                    parameters.Add(new SqlParameter("@Tipologia", SqlDbType.Int) { Value = Convert.ToInt32(inputUtente) });
                    break;

                case "Citta":
                    query = "SELECT * FROM AnagraficaRistoranti WHERE Citta = @Citta";
                    parameters.Add(new SqlParameter("@Citta", SqlDbType.VarChar) { Value = inputUtente });
                    break;

                case "Prezzo":
                    string prezzo = inputUtente.Contains(",") ? inputUtente.Replace(",", ".") : inputUtente;  //da virgola a punto
                    query = "SELECT * FROM AnagraficaRistoranti WHERE PrezzoMedio = @PrezzoMedio";
                    parameters.Add(new SqlParameter("@PrezzoMedio", SqlDbType.Decimal) { Value = Convert.ToDecimal(prezzo) });
                    break;

                default:
                    return null;  // Se il filtro non è riconosciuto
            }

            DataTable tableRistoranti = dbData.ExecuteCommand(query, parameters);

            List<Ristorante> ristorantiFiltrati = new List<Ristorante>();

            foreach (DataRow row in tableRistoranti.Rows)
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
                );
                ristorantiFiltrati.Add(ristorante);
            }

            return ristorantiFiltrati;
        }


        public DataTable GetDatiElencoRistoranti()
        {
            //messe le prime 3 e poi nascoste dal datagridview nel form elencoRistoranti
            string query = @"
            SELECT IdRistorante, 
                   AnagraficaRistoranti.Tipologia, 
                   AnagraficaRistoranti.NumPosti,
                   AnagraficaRistoranti.PartitaIva, 
                   Descrizione AS TipoRistorante, 
                   RagioneSociale, 
                   Indirizzo, 
                   Citta, 
                   Telefono
            FROM AnagraficaRistoranti
            LEFT JOIN Tipologia ON AnagraficaRistoranti.Tipologia = Tipologia.Tipologia";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Chiamo il metodo ExecuteSelectCommand per ottenere i dati
            return dbData.ExecuteCommand(query, parameters);
        }


        public Dictionary<string, decimal> GetGuadagniPerMese2024()
        {
            //converte in mese e anno, Calcola il guadagno totale per ogni prenotazione, filtra
            string query = @"
        SELECT 
            FORMAT(P.DataPrenotazione, 'MMMM yyyy') AS MeseAnno, 
            SUM(R.PrezzoMedio * P.NumPersone) AS GuadagnoMensile
        FROM 
            Prenotazioni P
        JOIN 
            AnagraficaRistoranti R ON P.IDRistorante = R.IDRistorante
        WHERE 
            P.DataPrenotazione >= '2024-01-01' AND P.DataPrenotazione < '2025-01-01'
        GROUP BY 
            FORMAT(P.DataPrenotazione, 'MMMM yyyy')
        ORDER BY 
            MeseAnno;
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

    }
}
