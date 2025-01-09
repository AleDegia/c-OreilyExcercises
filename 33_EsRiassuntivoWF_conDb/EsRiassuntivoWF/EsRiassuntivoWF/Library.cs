
using System.Collections.Generic;

namespace GestioneBiblioteca
{
    public class Library
    {
        //lista di tutti i prodotti
        public  List<LibraryProduct> Products { get; set; } = new List<LibraryProduct>();

        public Library(List<LibraryProduct> products)
        {
            Products = products;
        }
    }
}
