#region Using directives
using System;

namespace VaryingReturnType
{
    public class Tester
    {
        // Overloaded method to triple an int value
        private int Triple(int val)
        {
            return 3 * val;
        }

        // Overloaded method to triple a long value
        private long Triple(long val)
        {
            return 3 * val;
        }

        // Method to test the overloaded Triple methods
        public void Test()
        {
            // Test with int
            int x = 5;
            int y = Triple(x);
            Console.WriteLine("x: {0} y: {1}", x, y);

            // Test with long
            long lx = 10;
            long ly = Triple(lx);
            Console.WriteLine("lx: {0} ly: {1}", lx, ly);
        }

        // Entry point of the application
        static void Main()
        {
            // Create an instance of Tester and execute the test
            Tester t = new Tester();
            t.Test();
        }
    }
}
#endregion
