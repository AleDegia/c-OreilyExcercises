

using System;

namespace GestioneBiblioteca3
{
    public abstract class LibraryProduct
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }

        protected LibraryProduct(string name, string category, double price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public virtual void CheckDetails()
        {
            Console.WriteLine($"Nome: {Name}, Categoria: {Category}, Quantità: {Quantity}, Prezzo: {Price}");
        }


    }
}
