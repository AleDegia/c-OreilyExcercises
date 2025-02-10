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
            string query;

            //!questo va nella logica di business
            switch(filtro)
            {
                case "Tipologia":
                    query = $"SELECT * FROM AnagraficaRistoranti WHERE Tipologia = {inputUtente}";
                    string connectionString = dbData.GetConnectionString();
                    List<Ristorante> ristorantiFiltrati = new List<Ristorante>();

                    using (var adapter = new SqlDataAdapter(query, connectionString))
                    {
                        var tableRistoranti = new DataTable();
                        adapter.Fill(tableRistoranti);

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
                                   //)
                                   );
                                ristorantiFiltrati.Add(ristorante);
                        }
                    }
                    return ristorantiFiltrati;

                case "Citta":
                    query = $"SELECT * FROM AnagraficaRistoranti WHERE Citta = '{inputUtente}'";
                    connectionString = dbData.GetConnectionString();
                    ristorantiFiltrati = new List<Ristorante>();

                    using (var adapter = new SqlDataAdapter(query, connectionString))
                    {
                        var tableRistoranti = new DataTable();
                        adapter.Fill(tableRistoranti);

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
                               //)
                               );
                            ristorantiFiltrati.Add(ristorante);
                        }
                    }
                    return ristorantiFiltrati;

                case "Prezzo":
                    //converto la , a . siccome non va bene
                    string input = null;
                    if(inputUtente.Contains(","))
                    {
                        input = inputUtente.Replace(",", ".");
                    }
                    query = $"SELECT * FROM AnagraficaRistoranti WHERE PrezzoMedio = '{input}'";
                    connectionString = dbData.GetConnectionString();
                    ristorantiFiltrati = new List<Ristorante>();

                    using (var adapter = new SqlDataAdapter(query, connectionString))
                    {
                        var tableRistoranti = new DataTable();
                        adapter.Fill(tableRistoranti);

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
                    }

                    return ristorantiFiltrati;
            }
            //!

            return null;
        }

        public DataTable GetDatiElencoRistoranti()
        {
            string query = $"Select IdRistorante, AnagraficaRistoranti.Tipologia, Descrizione as TipoRistorante, RagioneSociale, Indirizzo, Citta, Telefono FROM AnagraficaRistoranti left join Tipologia on AnagraficaRistoranti.Tipologia = Tipologia.Tipologia";
            string connectionString = dbData.GetConnectionString();

            DataTable tableRistoranti = new DataTable();

            using (var adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.Fill(tableRistoranti);
            }
            return tableRistoranti;
        }
    }
}
