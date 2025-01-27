
using System.Collections.Generic;
using GestioneBiblioteca3;
using EsRiassuntivoWF.DAL;
using System.Security.Policy;
using System.Windows.Forms;

namespace EsRiassuntivoWF.BLL
{
    public class LibraryService
    {
        private Dal dal;  // Dichiarazione del campo senza inizializzarlo qui
        private LibraryProduct existingProduct;
        ClientInventory inventory = new ClientInventory();


        // Costruttore per inizializzare 'dal'
        public LibraryService()
        {
            dal = new Dal(); // Inizializza dal nel costruttore
        }

        
        //aziono metodo del DAL che prende libri dal db e li metto in lista items
        public List<LibraryProduct> GetLibraryItems()
        {
            List<Book> books = dal.GetBooks();    
            List<Magazine> magazines = dal.GetMagazines();  
            List<LibraryProduct> items = new List<LibraryProduct>();
            items.AddRange(books);
            items.AddRange(magazines);
            return items;
        }

        public List<LibraryProduct> GetInventoryItems()
        {
            List<LibraryProduct> products = new List<LibraryProduct>();
            List<Book> books = dal.GetBooksFromInventory();
            List<Magazine> magazines = dal.GetAllMagazines();
            products.AddRange(books);
            products.AddRange(magazines);
            return products;
        }

        public LibraryProduct GetProduct(string name)
        {
            //se name è di tipo libro
            List<Magazine> magazines = dal.GetAllMagazines();
            List<Book> books = dal.GetAllBooks();
            //Book prod = dal.GetBook(name);
            foreach(Book book in books)
                if(book.GetTitle() == name)
                    return book;
            foreach (Magazine magazine in magazines)
                if (magazine.GetTitle() == name)
                    return magazine;

            return null;
        }

        public bool InsertProduct(LibraryProduct product)
        {
            bool result = dal.InsertProduct(product);
            if(result) MessageBox.Show("Acquisto avvenuto con successo"); //da far vedere solo se avviene
            return result;
        }

        public void UpdateBooks(Book book)
        {
            dal.UpdateBooks(book);
        }

        public void UpdateMagazine(Magazine mag)
        {
            dal.UpdateMagazine(mag);
        }

        public void DeleteProduct(string name)
        {
            dal.DeleteProduct(name);
        }

        public bool PurchaseItem(LibraryProduct product, Client client)
        {
            if (client.GetMoney() < product.Price)
                return false;

            client.SetMoney(client.GetMoney() - product.Price);
            return true;
        }

        public LibraryProduct checkProduct(LibraryProduct existingProduct, double money)
        {

            if (existingProduct != null && money >= 0 && existingProduct is Book)
            {
                var bookProduct = (Book)existingProduct;
                //aggiungo prodotto a inventario cliente
                LibraryProduct purchasedProduct = new Book(
                   bookProduct.Id,
                   bookProduct.Name,
                   bookProduct.Category,
                   bookProduct.Price,
                   bookProduct.Quantity,
                   bookProduct.GetPagesNumber(),
                   bookProduct.GetTitle(),
                   bookProduct.GetAuthor(),
                   bookProduct.GetPublishingDate()
               );
                inventory.Products.Add(purchasedProduct);
                return purchasedProduct;
            }
            //MessageBox.Show("Acquisto avvenuto con successo");
            else if (existingProduct != null && money >= 0 && existingProduct is Magazine)
            { 
                Magazine magazineProduct = (Magazine)existingProduct;
                LibraryProduct purchasedProduct = new Magazine(
                    magazineProduct.Id,
                    magazineProduct.Name,
                    magazineProduct.Category,
                    magazineProduct.Price,
                    magazineProduct.Quantity,
                    magazineProduct.GetTitle(),
                    magazineProduct.GetDescription(),
                    magazineProduct.GetImg()
                );
                inventory.Products.Add(purchasedProduct);
                return purchasedProduct;
            }
            else
            {
                MessageBox.Show("Non hai abbastanza soldi");
                return null;
            }
        }
    }
}