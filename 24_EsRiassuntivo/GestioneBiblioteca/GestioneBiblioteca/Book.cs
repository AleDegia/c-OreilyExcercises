
namespace GestioneBiblioteca
{
    public class Book : LibraryProduct
    {

        public int PagesNumber { get; set; }
        
        public string Title { get; set; }   

        public string Author { get; set; }
        public DateTime PublishingDate { get; set; }

        public Book(string name, string category, double price, int quantity, int pages, string title, string author, DateTime publishingDate) 
            : base(name, category, price, quantity)
        {
            Title = title;
            Author = author;
            PagesNumber = pages;
            PublishingDate = publishingDate;
        }

        public override void CheckDetails()
        {
            base.CheckDetails();
            Console.WriteLine($"Titolo libro: {Title}, Prezzo: {Price}");
        }
    }
}
