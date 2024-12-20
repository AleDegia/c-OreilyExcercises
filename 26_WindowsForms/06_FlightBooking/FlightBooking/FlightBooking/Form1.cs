using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightBooking
{
    public partial class Form1 : Form
    {
        public static Boolean passport, IDCard;
        public static string ToolBar, To, From, StatTripDate, EndTripDate, FirstName, LastName, DocumentNo, IssueDate, ExpiryDate, WeightBaggage;
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void rdbId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbId.Checked)
            {
                lblDocNo.Text = "Id Card number:";
                lblIssueDate.Text = "Id Card Issue Date";
                lblExpirtyDate.Text = "IdCard Expiry Date";

                IDCard = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 100;
            monthCalendar1.ShowToday = true;
            numericUpDown1.Increment = 5;
            numericUpDown1.ReadOnly = true;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            To = txtTo.Text;
            From = txtFrom.Text;

            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            DocumentNo = txtBox.Text;

            IssueDate = dateTimePicker1.Value.ToString("dd MMM yyyy");
            ExpiryDate = dateTimePicker2.Value.ToString("dd MMM yyyy");

            WeightBaggage = numericUpDown1.Value.ToString();

            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            dateTimePicker2.MinDate = dt;
        }

        private void rdbPassport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPassport.Checked)
            {
                lblDocNo.Text = "Passport number:";
                lblIssueDate.Text = "Passport Issue Date";
                lblExpirtyDate.Text = "Passport Expiry Date";

                passport = true;
            }
        }
    }
}
