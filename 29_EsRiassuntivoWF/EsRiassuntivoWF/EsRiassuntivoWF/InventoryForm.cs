using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsRiassuntivoWF
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }

        // Metodo pubblico per aggiungere un prodotto alla ListBox
        public void AddProductToList(string productName)
        {
            listBoxInventario.Items.Add(productName);
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {

        }

        private void listBoxInventario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
