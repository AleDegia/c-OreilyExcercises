

using System.Collections.Generic;
using System;
using System.Linq;

namespace GestioneBiblioteca
{
    public class Client : Person
    {

        //private bool Buyer { get; set; } = true;
        private double Money { get; set; }
        //inizializzo qui poichè non è un valore personaizzato
        private ClientInventory Inventory { get; set; } = new ClientInventory();

        public Client(double money)
        {
            Money = money;
        }

        // Metodo getter per accedere a Money
        public double GetMoney()
        {
            return Money;
        }
        public void SetMoney(double money)
        { this.Money = money; }
        public double SetMoney2(double money)
        { return money; }


        // Public property to access Inventory from outside
        public ClientInventory GetInventory()
        {
            return Inventory;
        }

        Book bookProduct;
        Magazine magazineProduct;


        //mettendo 1 libro mette 2 oggetti dentro inventory
        public bool Buy(string name, int quantity, ClientInventory inventory)
        {
            //se il prodotto è disponibile in magazzino(Library)
            var existingProduct = Library.Products.FirstOrDefault(p => p.Name == name);

            Money -= (existingProduct.Price * quantity);


            //bookProduct.BuyBook(name, quantity, ref availableMoney, Inventory, existingProduct);
            if (existingProduct is Book)
            {
                if (existingProduct != null && existingProduct.Quantity >= quantity && Money >= 0)
                {
                    bookProduct = (Book)existingProduct;
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
                    for (int n = 0; n < quantity; n++)
                        inventory.Products.Add(purchasedProduct);
                    Console.WriteLine("Acquisto avvenuto con successo");
                }
                else
                {
                    Console.WriteLine("Non hai abbastanza soldi");
                    return false;
                }

            }
            else if (existingProduct is Magazine)
            {
                if (existingProduct != null && existingProduct.Quantity >= quantity && Money >= 0)
                {
                    magazineProduct = (Magazine)existingProduct;
                    LibraryProduct purchasedProduct = new Magazine(
                        magazineProduct.Name,
                        magazineProduct.Category,
                        magazineProduct.Price,
                        magazineProduct.Quantity,
                        magazineProduct.GetTitle(),      //trovare un modo per accedere tenendo private -> faccio il metodo direttamente nella sua classe
                        magazineProduct.GetDescription(),
                        magazineProduct.GetImg()
                    );
                    for (int n = 0; n < quantity; n++)
                        inventory.Products.Add(purchasedProduct);
                    Console.WriteLine("Acquisto avvenuto con successo");
                }

                else
                {
                    Console.WriteLine("Non hai abbastanza soldi");
                    return false;
                }
            }
            return true;
        }

        //}

        public void SeeAllBooks()
        {
            Console.WriteLine("Ecco i libri disponibili: ");
            foreach (var item in Library.Products)
            {
                if (item is Book book)
                {
                    Console.WriteLine(book.GetTitle());
                }
            }

        }

        public void SeeAllMagazines()
        {
            Console.WriteLine("Ecco le riviste disponibili: ");
            foreach (var item in Library.Products)
            {
                if (item is Magazine magazine)
                {
                    Console.WriteLine(magazine.Title);
                }
            }
        }


        //vedi i prodotti nell'inventario
        public void SeeInventory()
        {
            Console.WriteLine("SeeInventory(): ");
            List<string> namesList = Inventory.RetriveNames();
        }

        public LibraryProduct SearchProductFromLibrary(string name)
        {
            return null;
        }

        public LibraryProduct SeeInventoryProductDetails(string name)
        {
            return null;
        }


    }

}
