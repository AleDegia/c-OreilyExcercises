namespace Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // key - value
            // Declaring and initializing a Dictionary
            Dictionary<int, string> employees = new Dictionary<int, string>();

            // Adding Items to a Dictionary
            employees.Add(101, "John Doe");
            employees.Add(102, "Bob Smith");
            employees.Add(103, "Rob Smith");
            employees.Add(104, "Flob Smith");
            employees.Add(105, "Dob Smith");

            // access items in a dictionary
            string name = employees[101];
            //Console.WriteLine(name);

            // update data in a dictionary
            employees[102] = "Jane Smith";

            // remove an item from a dictionary
            employees.Remove(101);

            if (!employees.ContainsKey(104))
            {
                employees.Add(104, "Bob");
            }


            // Iterating over a dictionary
            foreach (KeyValuePair<int, string> employee in employees)
            {
                Console.WriteLine($"ID: {employee.Key}, Name: {employee.Value}");
            }



            Console.ReadKey();
        }
    }
}



/*
Dictionary<TKey, TValue> è una struttura di dati generica, il che significa che puoi specificare esattamente i tipi per le chiavi (TKey) e 
i valori (TValue).
Hashtable, d'altra parte, non è generica e accetta chiavi e valori di tipo object, quindi non è sicura dal punto di vista dei tipi (tipo-unsafe).
(nell'Hashtable chiavi e valori se non sono oggetti vengono subito autoboxati ad oggetti)

Non puoi aggiungere un item lla stessa ciave di un altro item
*/