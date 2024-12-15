using System;
using System.Collections.Generic;
using System.Text;
namespace ConvertingArrays
{
    // create an object we can
    // store in the array
    public class Employee
    {
        // a simple class to store in the array
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
        // This method takes an array of objects.
        // We'll pass in an array of Employees
        // and then an array of strings.
        // The conversion is implicit since both Employee
        // and string derive (ultimately) from object.
        public static void PrintArray(object[] theArray)
        {
            Console.WriteLine("Contents of the Array {0}",
            theArray.ToString());
            // walk through the array and print
            // the values.
            foreach (object obj in theArray)
            {
                // Chiama ToString() sull'elemento obj (se era Employee chiama il suo ToString())
                Console.WriteLine("Value: {0}", obj);
            }
        }
        static void Main()
        {
            // make an array of Employee objects
            Employee[] myEmployeeArray = new Employee[3];
            // initialize each Employee's value
            for (int i = 0; i < 3; i++)
            {
                myEmployeeArray[i] = new Employee(i + 5);
            }
            //l'array di tipo Employee[] viene convertito implicitamente in un array di object[].
            PrintArray(myEmployeeArray);    
            // create an array of two strings
            string[] array = { "hello", "world" };
            // print the value of the strings
            PrintArray(array);
        }
    }
}


/*
 * Il metodo PrintArray è progettato per funzionare con un array generico di tipo object[]. 
 * Questo consente di accettare array di qualsiasi tipo, purché i loro elementi derivino da object.
C# consente questa conversione perché Employee e string sono tipi derivati da object.

theArray.ToString() perchè stampa System.Employee[]?

il metodo ToString() sulla classe base System.Array non è sovrascritto per restituire una rappresentazione 
significativa del contenuto dell'array.


*/