using System.Diagnostics;

namespace TryCatchExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age");
            GetUserAge(Console.ReadLine());

            Console.ReadKey();

        }

        // What Does throw Do?
        // The throw keyword in C# is used to indicate that a problem
        // has occurred in your program
        // When you use throw, you're essentially saying,
        // "Hey, something went wrong here, and I can't handle it by myself." 
        // You're creating an error on purpose, which is called an exception.

        // Why use throw?
        /*
         * 1. To Stop Bad Things from Happening: If something in your program 
         * isn't right, like if a necessary file is missing or a number
         * that should never be zero is zero, using throw stops the program
         * before any more damage can happen.
         * 
         * 2. To Tell Other Parts of Your Program about the Problem: 
         * Sometimes, one part of your program might not know 
         * how to fix a problem, but another part does. By using throw,
         * the first part can let the second part handle the issue.
         * 
         */

        static int GetUserAge(string input)
        {
            int age;
            if (!int.TryParse(input, out age))
            {
                throw new Exception("You didn't enter a valid age.");
            }
            if (age < 0 || age > 120)
            {
                throw new Exception("Your age must be between 0 and 120.");
            }
            return age;
        }
    }
}

/*
 * int.TryParse(input, out age) tenta di convertire la stringa input in un numero intero. 
 * Se la conversione è riuscita, la variabile age conterrà il numero e l'espressione restituirà true.
 * */