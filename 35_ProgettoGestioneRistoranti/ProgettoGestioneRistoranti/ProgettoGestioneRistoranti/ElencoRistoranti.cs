using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Engine;
using Models;
using UI;

namespace ProgettoGestioneRistoranti
{
    public partial class ElencoRistoranti : Form
    {
        BlRistoranti bl;
        InsertRistorante insertRistorante;
        UpdateRistorante updateRistorante;
        private Ristorante ristorante;
        private FormPrenotazione formPrenotazione;
        public ElencoRistoranti()
        {
            InitializeComponent();
            bl = new BlRistoranti();
            insertRistorante = new InsertRistorante(this);
            //formPrenotazione = new FormPrenotazione();


        }

        public Ristorante GetRistorante() { return ristorante; }

        public void AggiungiColonne()
        {
            dataGridView1.Columns.Add("IDRistorante", "ID Ristorante");
            dataGridView1.Columns.Add("Tipologia", "Tipologia");
            dataGridView1.Columns.Add("Indirizzo", "Indirizzo");
            dataGridView1.Columns.Add("Citta", "Città");
            dataGridView1.Columns.Add("NumPosti", "Numero Posti");
            dataGridView1.Columns.Add("PrezzoMedio", "Prezzo Medio");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("RagioneSociale", "Ragione Sociale");
            dataGridView1.Columns.Add("PartitaIva", "Partita IVA");
        }

        public void AggiungiRighe(List<Ristorante> ristoranti)
        {
            foreach (var ristorante in ristoranti)
            {
                dataGridView1.Rows.Add(
                    ristorante.GetIDRistorante(),
                    ristorante.GetTipologia(),
                    ristorante.GetIndirizzo(),
                    ristorante.GetCitta(),
                    ristorante.GetNumPosti(),
                    ristorante.GetPrezzoMedio(),
                    ristorante.GetTelefono(),
                    ristorante.GetRagioneSociale(),
                    ristorante.GetPartitaIva()
                );
            }
        }

        private Ristorante GetRistoranteFromSelectedRow(DataGridViewRow row)
        {
            int idRistorante = Convert.ToInt32(row.Cells["IDRistorante"].Value);
            int tipologiaRistorante = Convert.ToInt32(row.Cells["Tipologia"].Value);
            string indirizzoRistorante = row.Cells["Indirizzo"].Value.ToString();
            string citta = row.Cells["Citta"].Value.ToString();
            int numPostiRistorante = Convert.ToInt32(row.Cells["NumPosti"].Value);
            decimal prezzoMedioRistorante = Convert.ToDecimal(row.Cells["NumPosti"].Value);
            string telefono = row.Cells["Telefono"].Value.ToString();
            string ragioneSocialeRistorante = row.Cells["RagioneSociale"].Value.ToString();
            string partitaIvaRistorante = row.Cells["PartitaIva"].Value.ToString();

            return ristorante = new Ristorante(
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
        }

        public void CleanDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void ElencoRistoranti_Load(object sender, EventArgs e)
        {
            AggiungiColonne();

            var ristoranti = bl.GetRistorantiFiltrati();

            // Aggiungi manualmente le righe
            AggiungiRighe(ristoranti);
            dataGridView1.Columns["IDRistorante"].Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            insertRistorante.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //prendo le info (id) del ristorante selezionato
            if (dataGridView1.SelectedRows.Count > 0)
            {

                //riga selezionata
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // recupero valori celle e ritorno ristrante
                ristorante = GetRistoranteFromSelectedRow(row);
                updateRistorante = new UpdateRistorante(ristorante, this);
                updateRistorante.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                CleanDataGridView();

                AggiungiColonne();

                var ristoranti = bl.GetRistorantiFiltrati();

                // Aggiungi manualmente le righe
                AggiungiRighe(ristoranti);

            }
        }

        private void textBoxEnterEvent(object sender, KeyEventArgs e)
        {
            string scelta = null;

            if(e.KeyCode == Keys.Enter)
            {
                scelta = comboBox1.Text;
                if (scelta == null)
                    MessageBox.Show("non hai scelto nessun filtro");

                List<Ristorante> ristorantiFiltrati = bl.GetRistorantiFiltrati2(scelta, textBox1.Text);

                CleanDataGridView();
                dataGridView1.Columns.Clear();

                AggiungiColonne();

                AggiungiRighe(ristorantiFiltrati);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                //riga selezionata
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // recupero valori celle
                ristorante = GetRistoranteFromSelectedRow(row);
                formPrenotazione = new FormPrenotazione(ristorante);
                formPrenotazione.Show();
            }
            else
            {
                MessageBox.Show("Seleziona un ristorante!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }



        //COMANDI PER PARTE GRAFICA DI CAMBIO COLORE ALL'OVERLAY DEL MOUSE
        private void backArrow_MouseEnter(object sender, EventArgs e)
        {
            // Sposta il bottone leggermente in alto (simula un "sollevamento")
            button5.Location = new Point(button5.Location.X, button5.Location.Y - 5);  // Muove di 5 pixel verso l'alto
        }

        private void backArrow_MouseLeave(object sender, EventArgs e)
        {
            // Riporta il bottone nella posizione originale
            button5.Location = new Point(button5.Location.X, button5.Location.Y + 5);  // Riporta di 5 pixel giù
        }
    }
}
