using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
using Models;

namespace ProgettoGestioneRistoranti
{
    public partial class ElencoRistoranti : Form
    {
        BlRistoranti bl;
        InsertRistorante insertRistorante;
        UpdateRistorante updateRistorante;
        private Ristorante ristorante;
        public ElencoRistoranti()
        {
            InitializeComponent();
            bl = new BlRistoranti();
            insertRistorante = new InsertRistorante(this);
            //updateRistorante = new UpdateRistorante();
        }

        public Ristorante GetRistorante() { return ristorante; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //prendo le info (id) del ristorante selezionato
            if (dataGridView1.SelectedRows.Count > 0)
            {

                //riga selezionata
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // recupero valori celle
                int idRistorante = Convert.ToInt32(row.Cells["IDRistorante"].Value);
                int tipologiaRistorante = Convert.ToInt32(row.Cells["Tipologia"].Value);
                string indirizzoRistorante = row.Cells["Indirizzo"].Value.ToString();
                string ragioneSocialeRistorante = row.Cells["RagioneSociale"].Value.ToString();
                string partitaIvaRistorante = row.Cells["PartitaIva"].Value.ToString();
                int numPostiRistorante = Convert.ToInt32(row.Cells["NumPosti"].Value);
                decimal prezzoMedioRistorante = Convert.ToDecimal(row.Cells["NumPosti"].Value);
                string telefono = row.Cells["Telefono"].Value.ToString();
                string citta = row.Cells["Citta"].Value.ToString();

                ristorante = new Ristorante(
                    idRistorante,
                    tipologiaRistorante, 
                    indirizzoRistorante,
                    ragioneSocialeRistorante,
                    partitaIvaRistorante,
                    numPostiRistorante,
                    prezzoMedioRistorante,
                    telefono,
                    citta
                );
                updateRistorante = new UpdateRistorante(ristorante, this);
                updateRistorante.Show();

            }
            else
            {
                MessageBox.Show("Seleziona un ristorante dalla lista.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void ElencoRistoranti_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("IDRistorante", "ID Ristorante");
            dataGridView1.Columns.Add("Tipologia", "Tipologia");
            dataGridView1.Columns.Add("Indirizzo", "Indirizzo");
            dataGridView1.Columns.Add("RagioneSociale", "Ragione Sociale");
            dataGridView1.Columns.Add("PartitaIva", "Partita IVA");
            dataGridView1.Columns.Add("NumPosti", "Numero Posti");
            dataGridView1.Columns.Add("PrezzoMedio", "Prezzo Medio");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("Citta", "Città");

            var ristoranti = bl.GetRistorantiFiltrati("", "", 0);

            // Aggiungi manualmente le righe
            foreach (var ristorante in ristoranti)
            {
                dataGridView1.Rows.Add(
                    ristorante.GetIDRistorante(),
                    ristorante.GetTipologia(),
                    ristorante.GetIndirizzo(),
                    ristorante.GetRagioneSociale(),
                    ristorante.GetPartitaIva(),
                    ristorante.GetNumPosti(),
                    ristorante.GetPrezzoMedio(),
                    ristorante.GetTelefono(),
                    ristorante.GetCitta()
                );
            }

            
            //dataGridView1.DataSource = ristoranti;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            insertRistorante.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //prendo le info (id) del ristorante selezionato
            if (dataGridView1.SelectedRows.Count > 0)
            {

                //riga selezionata
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                // recupero valore chiave primaria
                string valore = row.Cells[0].Value.ToString();
                MessageBox.Show("valore è " + valore);

                bl.CancellaRistorante(valore, "AnagraficaRistoranti");
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Add("IDRistorante", "ID Ristorante");
                dataGridView1.Columns.Add("Tipologia", "Tipologia");
                dataGridView1.Columns.Add("Indirizzo", "Indirizzo");
                dataGridView1.Columns.Add("RagioneSociale", "Ragione Sociale");
                dataGridView1.Columns.Add("PartitaIva", "Partita IVA");
                dataGridView1.Columns.Add("NumPosti", "Numero Posti");
                dataGridView1.Columns.Add("PrezzoMedio", "Prezzo Medio");
                dataGridView1.Columns.Add("Telefono", "Telefono");
                dataGridView1.Columns.Add("Citta", "Città");

                var ristoranti = bl.GetRistorantiFiltrati("", "", 0);

                // Aggiungi manualmente le righe
                foreach (var ristorante in ristoranti)
                {
                    dataGridView1.Rows.Add(
                        ristorante.GetIDRistorante(),
                        ristorante.GetTipologia(),
                        ristorante.GetIndirizzo(),
                        ristorante.GetRagioneSociale(),
                        ristorante.GetPartitaIva(),
                        ristorante.GetNumPosti(),
                        ristorante.GetPrezzoMedio(),
                        ristorante.GetTelefono(),
                        ristorante.GetCitta()
                    );
                }

            }
        }
    }
}
