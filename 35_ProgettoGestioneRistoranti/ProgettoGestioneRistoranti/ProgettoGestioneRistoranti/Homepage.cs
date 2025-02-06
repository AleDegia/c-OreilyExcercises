using ProgettoGestioneRistoranti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Homepage : Form
    {
        private ElencoRistoranti elencoRistoranti;
        private ElencoUtenti elencoUtenti;
        private ElencoPrenotazioni elencoPrenotazioni;
        public Homepage()
        {
            InitializeComponent();
            elencoRistoranti = new ElencoRistoranti();
           
            elencoPrenotazioni = new ElencoPrenotazioni();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // textBox2.BackColor = Color.FromArgb(74, 79, 99);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            elencoPrenotazioni.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            elencoRistoranti.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (elencoUtenti == null)
            {
                elencoUtenti = new ElencoUtenti();
            }
            elencoUtenti.Show();
            elencoUtenti.Activate();
        }
    }
}
