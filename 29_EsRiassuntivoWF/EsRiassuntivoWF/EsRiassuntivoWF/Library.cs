
using System.Collections.Generic;

namespace GestioneBiblioteca
{
    public static class Library
    {
        //lista di tutti i prodotti
        public static List<LibraryProduct> Products { get; set; } = new List<LibraryProduct>();

        //public Library(List<LibraryProduct> products)
        //{
        //    Products = products;
        //}
    }
}
