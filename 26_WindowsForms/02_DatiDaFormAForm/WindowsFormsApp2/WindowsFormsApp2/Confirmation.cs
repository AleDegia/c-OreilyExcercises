using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Confirmation : Form
    {
        public Confirmation()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //metodo che si attiva quando carica/apre il form
        private void Confirmation_Load(object sender, EventArgs e)
        {
            //prendo il testo messo come input ai form
            lblFirstName.Text = SignUp.fName;
            lblLastName.Text = SignUp.lName;
            lblEmail.Text = SignUp.emailAddress;

            if(SignUp.sms)
            {
                lblSMS.Text = "✓";
            }
            if (SignUp.reports)
            {
                lblReports.Text = "✓";
            }
            if(SignUp.transactions)
            {
                lblTransactions.Text = "✓";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
