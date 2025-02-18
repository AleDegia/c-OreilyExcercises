﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestioneBiblioteca;

namespace EsRiassuntivoWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTime publicationDate = new DateTime(2008, 6, 1);
            DateTime publicationDate2 = new DateTime(1997, 6, 26);
            Book book = new Book("Libro Cronache", "Adventure", 29.99, 5, 1275, "Le cronache di Narnia", "C.S. Lewis", publicationDate);
            Book book2 = new Book("Libro Harry Potter", "Fantasy", 25.99, 16, 654, "Harry Potter", "J. K. Rowling", publicationDate2);
            //Book book3 = new Book("Libro Cronache", "Adventure", 29.99, 5, 1275, "Le cronache di Narnia", "C.S. Lewis", publicationDate);
            Magazine magazine = new Magazine("Rivista Focus", "Scienza", 9.99, 13, "Focus", "Bella rivista", "modella.png");

            Library.Products.Add(book);
            Library.Products.Add(book2);
            Library.Products.Add(magazine);

            lblBalance.Text = "100";

            foreach (LibraryProduct product in Library.Products)
                Console.WriteLine(product.Name);

            foreach (LibraryProduct product in Library.Products)
                libraryProducts.Items.Add(product.Name);
        }

        Client currentClient = new Client(100);
        ClientInventory inventory = new ClientInventory(); 
        

        private void button1_Click(object sender, EventArgs e)
        {
            //se il prodotto è disponibile in magazzino(Library)
            string existingProductName = label2.Text;
            var existingProduct = Library.Products.FirstOrDefault(p => p.Name == existingProductName);
            Console.WriteLine(existingProduct);
            double money = currentClient.SetMoney2(100);
            money -= existingProduct.Price;
            lblBalance.Text = money.ToString();
            


            //bookProduct.BuyBook(name, quantity, ref availableMoney, Inventory, existingProduct);
            if (existingProduct is Book)
            {
                if (existingProduct != null && money >= 0)
                {
                    var bookProduct = (Book)existingProduct;
                    //aggiungo prodotto a inventario cliente
                    LibraryProduct purchasedProduct = new Book(
                       bookProduct.Name,
                       bookProduct.Category,
                       bookProduct.Price,
                       bookProduct.Quantity,
                       bookProduct.GetPagesNumber(),
                       bookProduct.GetTitle(),
                       bookProduct.GetAuthor(),
                       bookProduct.GetPublishingDate()
                   );
                    //for (int n = 0; n < quantity; n++)
                        inventory.Products.Add(purchasedProduct);
                    Console.WriteLine("Acquisto avvenuto con successo");
                    

                    InventoryForm inventoryForm = new InventoryForm();
                    inventoryForm.AddProductToList(purchasedProduct.Name);
                    inventoryForm.Show();
                    //this.Hide();
                }
                else
                {
                    Console.WriteLine("Non hai abbastanza soldi");
                    //return false;
                }

            }
            else if (existingProduct is Magazine)
            {
                if (existingProduct != null && money >= 0)
                {
                    Magazine magazineProduct = (Magazine)existingProduct;
                    LibraryProduct purchasedProduct = new Magazine(
                        magazineProduct.Name,
                        magazineProduct.Category,
                        magazineProduct.Price,
                        magazineProduct.Quantity,
                        magazineProduct.GetTitle(),      //trovare un modo per accedere tenendo private -> faccio il metodo direttamente nella sua classe
                        magazineProduct.GetDescription(),
                        magazineProduct.GetImg()
                    );
                    //for (int n = 0; n < quantity; n++)
                        inventory.Products.Add(purchasedProduct);
                    Console.WriteLine("Acquisto avvenuto con successo");

                    InventoryForm inventoryForm = new InventoryForm();
                    inventoryForm.AddProductToList(purchasedProduct.Name);
                    inventoryForm.Show();
                    this.Hide();
                }

                else
                {
                    Console.WriteLine("Non hai abbastanza soldi");
                    //return false;
                }
            }
            //return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            label2.Text = libraryProducts.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
