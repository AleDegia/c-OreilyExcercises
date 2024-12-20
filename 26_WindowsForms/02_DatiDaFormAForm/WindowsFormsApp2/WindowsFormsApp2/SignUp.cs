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
    public partial class SignUp : Form
    {
        public static string fName;
        public static string lName;
        public static string emailAddress;
        public static Boolean sms;
        public static Boolean reports;
        public static Boolean transactions;

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void chkSms_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSms.Checked)
            {
                sms = true;
                lblSmsMessage.Text = "Services charges may apply for sms";
            }
            else
            {
                sms = false;
                lblSmsMessage.Text = ".....";
            }
        }

       

       

        private void chkTransactions_CheckedChanged(object sender, EventArgs e)
        {
             
            if (chkTransactions.Checked)
            {
                transactions = true;
                lblTransactionMessage.Text = "Services charges may apply for transaction";
            }
            else
            {
                transactions = false;
                lblTransactionMessage.Text = ".....";
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            fName = txtFirstName.Text;
            lName = txtLastName.Text;
            emailAddress = txtEmailAddress.Text;

            this.Hide();
            Confirmation c= new Confirmation();
            c.Show();

        }

        private void checkReports_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkReports.Checked)
            {
                reports = true;
                lblSmsMessage.Text = "Services charges may apply";
            }
            else
            {
                reports = false;
            }
        }
    
    }
}
