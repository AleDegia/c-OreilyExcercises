using System;
namespace ConstructorDemo
{
    public class StaticConstructor
    {
        static StaticConstructor()
        {
            Console.WriteLine("Static Constructor Executed!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Exceution Started...");
            Console.ReadKey();
        }
    }
}

/*
 Output:
 Static Constructor Executed!
 Main Method Exceution Started...
*/

/*
 * Now, when you execute the above code, the Static constructor will execute first and then the main method.
 * the static constructor never called explicitly.
 * The program execution will start from the Main method but before executing any statement inside the Main method, 
 * it will first execute the Static constructor and once the Static Constructor execution is completed, then it 
 * will continue the execution of the Main method. 
 * So Static Constructors cannot be parameterized.
*/