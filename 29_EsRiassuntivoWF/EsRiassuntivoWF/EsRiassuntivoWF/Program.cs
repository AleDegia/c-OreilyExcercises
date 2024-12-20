using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestioneBiblioteca;

namespace EsRiassuntivoWF
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            DateTime publicationDate = new DateTime(2008, 6, 1);
            DateTime publicationDate2 = new DateTime(1997, 6, 26);
            Book book = new Book("Libro Cronache", "Adventure", 29.99, 5, 1275, "Le cronache di Narnia", "C.S. Lewis", publicationDate);
            Book book2 = new Book("Libro Harry Potter", "Fantasy", 25.99, 16, 654, "Harry Potter", "J. K. Rowling", publicationDate2);
            //Book book3 = new Book("Libro Cronache", "Adventure", 29.99, 5, 1275, "Le cronache di Narnia", "C.S. Lewis", publicationDate);
            Magazine magazine = new Magazine("Rivista Focus", "Scienza", 9.99, 13, "Focus", "Bella rivista", "modella.png");

            Library.Products.Add(book);
            Library.Products.Add(book2);
            Library.Products.Add(magazine);

            foreach (LibraryProduct product in Library.Products)
                product.CheckDetails();    //'Libro Cronache'

            int booksQuantity = Library.Products.Count;
            Console.WriteLine("totale libri:" + booksQuantity.ToString());

            Client client = new Client(100.0);
            ClientInventory inventory = client.GetInventory();


            foreach (var item in Library.Products)
            {
                if (item is Book)
                {
                    Console.WriteLine(item.Name);
                }
            }


            Console.WriteLine("---- \n");
            string choice = "we";
            while (choice != "6")
            {

                Console.WriteLine("\nScegli un'azione: ");
                Console.WriteLine("1) Vedi libri, 2) vedi riviste, 3)vedi inventario, 4) vedi balance, 5) compra oggetto, 6) esci");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Hai scelto di vedere i libri.");
                        // Logica per mostrare i libri
                        client.SeeAllBooks();
                        break;

                    case "2":
                        Console.WriteLine("Hai scelto di vedere le riviste");
                        client.SeeAllMagazines();
                        break;

                    case "3":
                        Console.WriteLine("Hai scelto di vedere l'inventario dei libri acquistati");
                        List<string> names = inventory.RetriveNames();
                        if (names.Count == 0)
                            Console.WriteLine("L'inventario è vuoto");
                        break;

                    case "4":
                        Console.WriteLine("Ecco il tuo balance: ");
                        Console.WriteLine(client.GetMoney() + "$");
                        break;

                    case "5":
                        bool result = false;
                        var moneyBefore = client.GetMoney();
                        do
                        {
                            Console.WriteLine("Cosa vuoi comprare?");
                            string buyChoice = Console.ReadLine();
                            Console.WriteLine("Quantità?");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            result = client.Buy(buyChoice, quantity, inventory);
                            if (result == false)
                                client.SetMoney(moneyBefore);
                        } while (result == false);
                        break;

                    case "6":
                        break;
                }
            }






            //Title è una proprietà specifica della classe Book, mentre la variabile product nel foreach è del tipo base LibraryProduct
            //Per stampare Title, devi verificare se l'oggetto product è del tipo Book prima di accedere alla
            //proprietà Title. Puoi farlo utilizzando un controllo con is o un cast esplicito (tipo filtro prodotti)

            foreach (LibraryProduct product in inventory.Products)
            {
                if (product is Book)
                {
                    Console.WriteLine($"Name: {product.Name}, Title: {book.GetTitle()}");
                }
                else
                    Console.WriteLine(product.Name);

                //Un'altra opzione è aggiungere un metodo ToString personalizzato alle classi figlie,

            }


            //inventory.ShowInventory();
            //client.SeeInventory();
        }


    }
}

