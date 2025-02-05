using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLL;
using Engine;
using Models;

namespace ProgettoGestioneRistoranti
{
    public partial class ElencoPrenotazioni : Form
    {
        BlPrenotazioni bl;
        private Prenotazione prenotazione;
        private UpdatePrenotazione updatePrenotazione;
        public ElencoPrenotazioni()
        {
            InitializeComponent();
            bl = new BlPrenotazioni();
        }

        public void AggiungiColonne()
        {
            dataGridView1.Columns.Add("IDPrenotazione", "ID Prenotazione");
            dataGridView1.Columns.Add("IDRistorante", "ID Ristorante");
            dataGridView1.Columns.Add("NomeUtente", "Nome Utente");
            dataGridView1.Columns.Add("DataRichiesta", "Data Richiesta");
            dataGridView1.Columns.Add("DataPrenotazione", "Data Prenotazione");
            dataGridView1.Columns.Add("NumPersone", "Numero Persone");
        }

        public void AggiungiRighe(List<Prenotazione> prenotazioni)
        {
            foreach(var prenotazione in prenotazioni)
            {
                dataGridView1.Rows.Add(
                    prenotazione.IDPrenotazione,
                    prenotazione.IDRistorante,
                    prenotazione.NomeUtente,
                    prenotazione.DataRichiesta,
                    prenotazione.DataPrenotazione,
                    prenotazione.NumPersone
                );
            }
        }

        private Prenotazione GetPrenotazioneFromSelectedRow(DataGridViewRow row)
        {
            int idPrenotazione = Convert.ToInt32(row.Cells["IDPrenotazione"].Value);
            int idRistorante = Convert.ToInt32(row.Cells["IDRistorante"].Value);
            string nomeUtente = row.Cells["NomeUtente"].Value.ToString();
            DateTime dataRichiesta = Convert.ToDateTime(row.Cells["DataRichiesta"].Value);
            DateTime dataPrenotazione = Convert.ToDateTime(row.Cells["DataPrenotazione"].Value);
            int numPersone = Convert.ToInt32(row.Cells["NumPersone"].Value);

            return new Prenotazione(
                idPrenotazione,
                idRistorante,
                nomeUtente,
                dataRichiesta,
                dataPrenotazione,
                numPersone
            );
        }

        private void ElencoPrenotazioni_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("IDPrenotazione", "ID Prenotazione");
            dataGridView1.Columns.Add("IDRistorante", "ID Ristorante");
            dataGridView1.Columns.Add("NomeUtente", "Nome Utente");
            dataGridView1.Columns.Add("DataRichiesta", "Data Richiesta");
            dataGridView1.Columns.Add("DataPrenotazione", "Data Prenotazione");
            dataGridView1.Columns.Add("NumPersone", "Numero Persone");

            var prenotazioni = bl.GetPrenotazioni();

            foreach (var prenotazione in prenotazioni)
            {
                dataGridView1.Rows.Add(
                    prenotazione.IDPrenotazione,
                    prenotazione.IDRistorante,
                    prenotazione.NomeUtente,
                    prenotazione.DataRichiesta,
                    prenotazione.DataPrenotazione,
                    prenotazione.NumPersone
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //riga selezionata
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            // recupero valori celle e ritorno ristrante
            prenotazione = GetPrenotazioneFromSelectedRow(row);
            updatePrenotazione = new UpdatePrenotazione(prenotazione, this);
            updatePrenotazione.Show();
        }
    }
}
