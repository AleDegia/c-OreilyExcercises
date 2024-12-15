

namespace GestioneBiblioteca
{
    public class Client : Person
    {

        private bool Buyer { get; set; } = true;
        private double Money { get; set; }
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



        // Public property to access Inventory from outside
        public ClientInventory GetInventory()
        {
            return Inventory;
        }

        Book bookProduct;
        Magazine magazineProduct;


        public bool Buy(string name, int quantity) 
        {
            //se il prodotto è disponibile in magazzino(Library)
            var existingProduct = Library.Products.FirstOrDefault(p => p.Name == name);
            Money -= (existingProduct.Price*quantity);

            if (existingProduct != null && existingProduct.Quantity >= quantity && Money>=0)
            {
                if(existingProduct is Book)
                { 
                    bookProduct = (Book)existingProduct;
                    //aggiungo prodotto a inventario cliente
                    //Se tipo book  (usare generics?) (come faccio a renderlo ok per qualsiasi tipo di prodotto?)
                     LibraryProduct purchasedProduct = new Book(
                        bookProduct.Name,
                        bookProduct.Category,
                        bookProduct.Price,
                        bookProduct.Quantity,
                        bookProduct.PagesNumber,
                        bookProduct.Title,
                        bookProduct.Author,
                        bookProduct.PublishingDate
                    );
                    Inventory.Products.Add(purchasedProduct);
                    Console.WriteLine("Acquisto avvenuto con successo");
                }

                else if(existingProduct is Magazine)
                {
                    magazineProduct = (Magazine)existingProduct;
                    LibraryProduct purchasedProduct = new Magazine(
                        magazineProduct.Name,
                        magazineProduct.Category,
                        magazineProduct.Price,
                        magazineProduct.Quantity,
                        magazineProduct.Title,      //trovare un modo per accedere tenendo private -> faccio il metodo direttamente nella sua classe
                        magazineProduct.Description,
                        magazineProduct.Img
                    );
                    Inventory.Products.Add(purchasedProduct);
                    Console.WriteLine("Acquisto avvenuto con successo");
                }



                //levo quantity prodotti da Library 
                return true;
            }
            
            return false;
        }

        public void SeeAllBooks()
        {
            Console.WriteLine("Ecco i libri disponibili: ");
            foreach (var item in Library.Products)
            {
                if(item is Book book)   
                {
                    Console.WriteLine(book.Title);
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
