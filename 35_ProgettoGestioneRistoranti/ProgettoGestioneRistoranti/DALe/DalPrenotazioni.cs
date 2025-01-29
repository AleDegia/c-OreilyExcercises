using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public void AggiungiPrenotazione(Prenotazione prenotazione)
        {
            string connectionString = dbData.GetConnectionString();
            using (SqlConnection openCon = new SqlConnection(connectionString))
            {

                string query = "INSERT into Prenotazioni (IDPrenotazione, IDRistorante, NomeUtente, DataRichiesta, DataPrenotazione, NumPersone) VALUES (@IDPrenotazione, @IDRistorante,@NomeUtente, @DataRichiesta, @DataPrenotazione, @NumPersone)";
                
                    using (SqlCommand querySaveStaff = new SqlCommand(query))
                    {
                        querySaveStaff.Connection = openCon;
                        openCon.Open();

                        querySaveStaff.Parameters.AddWithValue("@IDPrenotazione", prenotazione.IDPrenotazione);
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
                            MessageBox.Show(ex.Message);
                        }
                    }
                
            }
        }

        public List<Prenotazione> GetAllPrenotazioni(int idRistorante)
        {
            string connectionString = dbData.GetConnectionString();
            string query = $"SELECT * FROM Prenotazioni WHERE IDRistorante = {idRistorante}";
            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            MessageBox.Show(idRistorante.ToString());

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
    }
}
