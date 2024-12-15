
namespace GestioneBiblioteca
{
    public class Magazine : LibraryProduct
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        public Magazine(string name, string category, double price, int quantity, string title, string description, string img)
            : base(name, category, price, quantity)
        {
            Title = title;
            Description = description;
            Img = img;
        }

        public override void CheckDetails()
        {
            Console.WriteLine($"Rivista: {Name}, Titolo: {Title}");
        }
    }
}
