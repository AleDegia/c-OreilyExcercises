
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