using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //per fare i bottoni nel messageBox uso la sua proprietà MessageBoxButtons, per displayare i 3 bottoni uso MessageBoxButtons.YesNoCancel
            DialogResult dr = MessageBox.Show("1: To Purchase, Press = Yes. \n 2: For trial Version, Press = 2 \n 3: Cancel Order", "Purchase Software", MessageBoxButtons.YesNoCancel);
            if(dr==DialogResult.Yes)
            {
                lblYesNo.Text = "You have purchased";
            }
            if (dr == DialogResult.No)
            {
                lblYesNo.Text = "Trial version started";
            }
            if (dr == DialogResult.Cancel)
            {
                lblYesNo.Text = "You have canceled the order";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
