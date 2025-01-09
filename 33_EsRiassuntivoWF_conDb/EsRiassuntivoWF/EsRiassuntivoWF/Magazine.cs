
using System;

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

        //Magazine magazineProduct;

        public override void CheckDetails()
        {
            Console.WriteLine($"Rivista: {Name}, Titolo: {Title}");
        }

        //public void BuyMagazine(string name, int quantity, ref double availableMoney, ClientInventory inventory, LibraryProduct existingProduct)
        //{
        //    if (existingProduct != null && existingProduct.Quantity >= quantity && availableMoney >= 0)
        //    {
        //        if (existingProduct is Magazine)
        //        {
        //            magazineProduct = (Magazine)existingProduct;
        //            LibraryProduct purchasedProduct = new Magazine(
        //                magazineProduct.Name,
        //                magazineProduct.Category,
        //                magazineProduct.Price,
        //                magazineProduct.Quantity,
        //                magazineProduct.Title,      //trovare un modo per accedere tenendo private -> faccio il metodo direttamente nella sua classe
        //                magazineProduct.Description,
        //                magazineProduct.Img
        //            );
        //            inventory.Products.Add(purchasedProduct);
        //            Console.WriteLine("Acquisto avvenuto con successo");
        //        }
        //    }
        //}

        public string GetTitle()
        {
            return Title;
        }
        public string GetDescription()
        {
            return Description;
        }
        public string GetImg()
        {
            return Img;
        }

        // Override di ToString per restituire il titolo (why??)
        public override string ToString()
        {
            return this.Title;  // Restituisci il titolo del libro come rappresentazione dell'oggetto
        }

    }
}
