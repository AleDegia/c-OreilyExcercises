
using System.Diagnostics;
using System;
using System.Xml.Linq;

namespace GestioneBiblioteca
{
    public class Book : LibraryProduct
    {

        private int PagesNumber { get; set; }

        private string Title { get; set; }

        private string Author { get; set; }
        private DateTime PublishingDate { get; set; }

        public Book(string name, string category, double price, int quantity, int pages, string title, string author, DateTime publishingDate)
            : base(name, category, price, quantity)
        {
            Title = title;
            Author = author;
            PagesNumber = pages;
            PublishingDate = publishingDate;
        }

        Book bookProduct;

        public override void CheckDetails()
        {
            base.CheckDetails();
            Console.WriteLine($"Titolo libro: {Title}, Prezzo: {Price}");
        }

        //faccio questo metodo da usare in client dentro Buy() per tenere private i campi di Book
        //public void BuyBook(string name, int quantity, ref double availableMoney, ClientInventory inventory, LibraryProduct existingProduct)
        //{

        //    if (existingProduct != null && existingProduct.Quantity >= quantity && availableMoney >= 0)
        //    {
        //        if (existingProduct is Book)
        //        {
        //            bookProduct = (Book)existingProduct;
        //            //aggiungo prodotto a inventario cliente
        //            //Se tipo book  (usare generics?) (come faccio a renderlo ok per qualsiasi tipo di prodotto?)
        //            LibraryProduct purchasedProduct = new Book(
        //               bookProduct.Name,
        //               bookProduct.Category,
        //               bookProduct.Price,
        //               bookProduct.Quantity,
        //               bookProduct.PagesNumber,
        //               bookProduct.Title,
        //               bookProduct.Author,
        //               bookProduct.PublishingDate
        //           );
        //            inventory.Products.Add(purchasedProduct);
        //            Console.WriteLine("Acquisto avvenuto con successo");
        //        }

        //    }
        //}

        public int GetPagesNumber()
        {
            return PagesNumber;
        }
        public string GetTitle()
        {
            return Title;
        }
        public string GetAuthor()
        {
            return Author;
        }
        public DateTime GetPublishingDate()
        {
            return PublishingDate;
        }


    }
}
