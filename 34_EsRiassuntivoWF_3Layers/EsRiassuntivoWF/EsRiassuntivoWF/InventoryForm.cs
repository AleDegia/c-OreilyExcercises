using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EsRiassuntivoWF.BLL;
using GestioneBiblioteca3;

namespace EsRiassuntivoWF
{
    public partial class InventoryForm : Form
    {
        LibraryService libraryService;
        public InventoryForm()
        {
            InitializeComponent();
            libraryService = new LibraryService();
        }

        // Metodo pubblico per aggiungere un prodotto alla ListBox
        public void AddProductToList(string productName)
        {
            listBoxInventario.Items.Add(productName);
        }

        //prendo i prodotti dal db
        private void InventoryForm_Load(object sender, EventArgs e)
        {
            List<LibraryProduct> prods = libraryService.GetInventoryItems();
            foreach(LibraryProduct prod in prods)
                listBoxInventario.Items.Add(prod.Name);
        }

        private void listBoxInventario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
