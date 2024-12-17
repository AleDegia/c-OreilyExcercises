
namespace GestioneBiblioteca
{
    public class ClientInventory
    {
        public List<LibraryProduct> Products { get; set; } = new List<LibraryProduct>();

        public List<LibraryProduct> GetProducts()
        {
            return Products;
        }

        public void ShowInventory()
        {
            Console.WriteLine("Inventario da 'ShowInventory()':");
            foreach (var product in Products)
            {
                //Chiama il CheckDetails della classe figlia se ho fatto l'override
                product.CheckDetails();
            }
        }

        public List<string> RetriveNames()
        {
            List<string> retrivedNames = new List<string>();
            foreach (var product in Products)
            {
                retrivedNames.Add(product.Name);
                Console.WriteLine(product.Name);
            }
            return retrivedNames;
        }
    }
}
