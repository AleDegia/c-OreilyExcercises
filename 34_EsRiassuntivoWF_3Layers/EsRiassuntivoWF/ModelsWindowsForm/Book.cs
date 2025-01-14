
using System.Diagnostics;
using System;
using System.Xml.Linq;

namespace GestioneBiblioteca3
{
    public class Book : LibraryProduct
    {
        private int PagesNumber { get; set; }

        private string Title { get; set; }

        private string Author { get; set; }
        private DateTime PublishingDate { get; set; }

        public Book(int id, string name, string category, double price, int quantity, int pages, string title, string author, DateTime publishingDate)
            : base(id, name, category, price, quantity)
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

        public void SetPagesNumber(int pages)
        {
            PagesNumber = pages;
        }
        public string GetTitle()
        {
            return Title;
        }
        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetAuthor(string name)
        {
            Author = name;
        }
        public string GetAuthor()
        {
            return Author;
        }

        public void SetPublishingDate(DateTime date)
        {
            PublishingDate = date;
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
