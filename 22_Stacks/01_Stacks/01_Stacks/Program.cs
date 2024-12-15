using System;
using System.Collections.Generic;
using System.Text;
namespace Stack
{
    public class Tester
    {
        static void Main()
        {
            Stack<Int32> intStack = new Stack<Int32>();
            // populate the array
            for (int i = 0; i < 8; i++)
            {
                intStack.Push(i * 5);
            }
            // Display the Stack.
            Console.Write("intStack values:\t");
            PrintValues(intStack);
            // Remove an element from the stack.
            Console.WriteLine("\n(Pop)\t{0}",
            intStack.Pop());    //leva l'ultimo inserito
            // Display the Stack.
            Console.Write("intStack values:\t");
            PrintValues(intStack);
            // Remove another element from the stack.
            Console.WriteLine("\n(Pop)\t{0}",
            intStack.Pop());
            // Display the Stack.
            Console.Write("intStack values:\t");
            PrintValues(intStack);
            // View the first element in the
            // Stack but do not remove.
            Console.WriteLine("\n(Peek) \t{0}",
            intStack.Peek());
            // Display the Stack.
            Console.Write("intStack values:\t");
            PrintValues(intStack);
            // declare an array object which will
            // hold 12 integers
            int[] targetArray = new int[12];
            for (int i = 0; i < targetArray.Length; i++)
            {
                targetArray[i] = i * 100 + 100;
            }
            // Display the values of the target Array instance.
            Console.WriteLine("\nTarget array: ");
            PrintValues(targetArray);
            // Copy the entire source Stack to the
            // target Array instance, starting at index 6.
            intStack.CopyTo(targetArray, 6);
            // Display the values of the target Array instance.
            Console.WriteLine("\nTarget array after copy: ");
            PrintValues(targetArray);
        }
        public static void PrintValues(
        IEnumerable<Int32> myCollection)
        {
            IEnumerator<Int32> enumerator =
            myCollection.GetEnumerator();
            while (enumerator.MoveNext())
                Console.Write("{0} ", enumerator.Current);
            Console.WriteLine();
        }
    }
}