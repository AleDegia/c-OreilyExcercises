
using System.Diagnostics;
using System;
using System.Xml.Linq;

namespace GestioneBiblioteca2
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

        // Override di ToString per restituire il titolo (why??)
        public override string ToString()
        {
            return this.Title;  // Restituisci il titolo del libro come rappresentazione dell'oggetto
        }


    }
}
