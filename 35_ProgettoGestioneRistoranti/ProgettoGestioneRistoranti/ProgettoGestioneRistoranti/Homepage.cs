﻿using ProgettoGestioneRistoranti;
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
        ElencoRistoranti elencoRistoranti;
        public Homepage()
        {
            InitializeComponent();
            elencoRistoranti = new ElencoRistoranti();
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            elencoRistoranti.Show();
        }
    }
}
