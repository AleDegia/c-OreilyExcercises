namespace Programming_CSharp
{
    // a simple class to store in the array
    public class Employee
    {
        public Employee(int empID)
        {
            this.empID = empID;
        }
        public override string ToString()
        {
            return empID.ToString();
        }
        private int empID;
    }
    public class Tester
    {
        static void Main()
        {
            int[] intArray;
            Employee[] empArray;
            intArray = new int[5];
            empArray = new Employee[3];
            // populate the array
            for (int i = 0; i < empArray.Length; i++)
            {
                empArray[i] = new Employee(i + 5);
            }
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i].ToString());
            }
            for (int i = 0; i < empArray.Length; i++)
            {
                Console.WriteLine(empArray[i].ToString());
            }
        }
    }
}


/*
 *  in .NET, System.Array è una classe. Fa parte dello spazio dei nomi System ed è la classe base per tutti gli array in C#.
 *  Anche se gli array in C# possono sembrare tipi primitivi, sono in realtà istanze della classe System.Array.
 *  
 *  Il metodo ToString() in questo codice funziona in modo diverso a seconda del tipo di oggetto che lo chiama.
 *  intArray è un array di interi (int[]). In C#, il tipo primitivo int è un alias per la struttura System.Int32, 
 *  che eredita il metodo ToString() dalla classe base System.Object.
    La chiamata a intArray[i].ToString() restituisce la rappresentazione in stringa dell'intero. 

    empArray è un array di oggetti della classe Employee. La classe Employee ha un override del metodo ToString().
    Questo significa che quando si chiama empArray[i].ToString(), viene eseguito il metodo personalizzato definito nella
    classe Employee. Questo metodo:
    Converte l'ID del dipendente (empID, un intero) in una stringa utilizzando empID.ToString().
    Restituisce questa stringa come risultato.
    Di conseguenza, la rappresentazione in stringa di un oggetto Employee sarà il valore del suo campo empID.


    La possibilità di chiamare il metodo ToString() sia su un intero che su un oggetto in C# è dovuta al fatto 
    che tutti i tipi in .NET derivano, direttamente o indirettamente, dalla classe base System.Object. 
    Questo include sia i tipi di valore (come int) che i tipi di riferimento (come le classi).
    e uno dei metodi definiti in essa è proprio ToString(). Ciò significa che:

   Ogni tipo (di valore o di riferimento) eredita il metodo ToString().
   Questo include sia i tipi primitivi come int (che è un alias per System.Int32) sia gli oggetti definiti dall'utente 
   come Employee.

*/  