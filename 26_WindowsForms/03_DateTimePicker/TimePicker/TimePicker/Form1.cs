using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimePicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            lblDateTime.Text = dateTimePicker.Value.ToString();
            //mostra solo data senza ora
            lblDate.Text = dateTimePicker.Value.ToShortDateString();
            //giorno, Mese e anno
            lbl3DateDay.Text = dateTimePicker.Value.ToLongDateString();
            //mostra solo ora
            lbl4Time.Text = dateTimePicker.Value.ToShortTimeString();
            //ora con secondi
            lblTimeSeconds.Text = dateTimePicker.Value.ToLongTimeString();
        }
    }
}
