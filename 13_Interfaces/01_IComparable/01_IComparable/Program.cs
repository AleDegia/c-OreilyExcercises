using System;
using System.Collections.Generic;
using System.Text;
namespace IComparable
{
    // IComparable è di tipo Employee perchè il confronto avverrà tra dati di questo tipo
    public class Employee : IComparable<Employee>
    {
        private int empID;
        public Employee(int empID)
        {
            this.empID = empID;
        }
        public override string ToString()
        {
            return empID.ToString();
        }
        public bool Equals(Employee other)
        {
            if (this.empID == other.empID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Employee rhs)
        {
            //comparo gli id dei 2 oggetti della classe Employee
            return this.empID.CompareTo(rhs.empID);
        }
    }
    public class Tester
    {
        static void Main()
        {
            List<Employee> empArray = new List<Employee>();
            List<Int32> intArray = new List<Int32>();
            // generate random numbers for both the integers and the
            // employee IDs
            Random r = new Random();

            // populate the array
            for (int i = 0; i < 5; i++)
            {
                // add a random employee id
                empArray.Add(new Employee(r.Next(10) + 100));
                // add a random integer
                intArray.Add(r.Next(10));
            }
            // display all the contents of the int array
            for (int i = 0; i < intArray.Count; i++)
            {
                Console.Write("{0} ", intArray[i].ToString());
            }
            Console.WriteLine("\n");
            // display all the contents of the Employee array
            for (int i = 0; i < empArray.Count; i++)
            {
                Console.Write("{0} ", empArray[i].ToString());
            }
            Console.WriteLine("\n");
            // sort and display the int array (stampa ordinati)
            intArray.Sort();
            for (int i = 0; i < intArray.Count; i++)
            {
                Console.Write("{0} ", intArray[i].ToString());
            }
            Console.WriteLine("\n");
            // sort and display the employee array (stampa ordinati)
            empArray.Sort();
            for (int i = 0; i < empArray.Count; i++)
            {
                Console.Write("{0} ", empArray[i].ToString());
            }
            Console.WriteLine("\n");
        }
    }
}


/*
 * Quando chiami empArray.Sort(), il metodo Sort() tenta di ordinare gli elementi della lista.
Poiché empArray contiene oggetti della classe Employee, il metodo Sort() verifica se la classe implementa 
un modo per confrontare gli oggetti, ovvero se implementa l'interfaccia IComparable<Employee>.

Quindi il metodo Sort() utilizza il metodo CompareTo per confrontare le coppie di oggetti Employee nella lista.
Ad esempio, durante l'ordinamento, il metodo Sort() può confrontare un oggetto Employee con un altro chiamando:

employee1.CompareTo(employee2);

Questo confronto restituisce:
-1 se employee1 deve essere posizionato prima di employee2 (il suo empID è minore).
0 se employee1 e employee2 sono considerati uguali (hanno lo stesso empID).
1 se employee1 deve essere posizionato dopo employee2 (il suo empID è maggiore).

Supponiamo che empArray contenga i seguenti oggetti Employee, con empID generati casualmente: 101, 105, 103, 102, 104.

Quando chiami empArray.Sort(), il metodo Sort() esegue chiamate successive a CompareTo su varie coppie di oggetti Employee:
employee1.CompareTo(employee2) confronta gli empID di due oggetti.

Il metodo intArray.Sort(); ordina automaticamente tutti gli elementi dell'array (o lista) senza bisogno di un ciclo 
for esplicito.
*/