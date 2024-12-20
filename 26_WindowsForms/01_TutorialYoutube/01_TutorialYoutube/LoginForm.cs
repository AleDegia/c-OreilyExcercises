using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_TutorialYoutube
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        public void Login()
        {
            string id = textUserid.Text;
            string password = textPassword.Text;

            if (id == "i25" && password == "123456")
            {
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
            else
            {
                MessageBox.Show("Password or email is incorrect");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        public void ResetForm()
        {
            textUserid.Text = "";
            textPassword.Text = "";
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ogniqualvolta viene premuto il tasto enter aziona il login
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
            if (e.KeyChar == (char)Keys.F1)
            {
                ResetForm();
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
