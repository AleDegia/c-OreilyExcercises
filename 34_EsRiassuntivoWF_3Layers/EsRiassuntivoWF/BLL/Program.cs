
using System.Collections.Generic;
using GestioneBiblioteca2;
using EsRiassuntivoWF.DAL;

namespace EsRiassuntivoWF.BLL
{
    public class LibraryService
    {
        private Dal dal;  // Dichiarazione del campo senza inizializzarlo qui

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
            var items = new List<LibraryProduct>();
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
    }
}