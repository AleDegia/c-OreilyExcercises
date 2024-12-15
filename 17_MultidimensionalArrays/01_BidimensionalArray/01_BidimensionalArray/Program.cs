using System;
using System.Collections.Generic;
using System.Text;
namespace RectangularArray
{
    public class Tester
    {
        static void Main()
        {
            const int rows = 4;
            const int columns = 3;
            // declare a 4x3 integer array (le righe a sinista, le colonne a destra)
            int[,] rectangularArray = new int[rows, columns];
            // populate the array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //vuol dire: cella a riga i e colonna j prende valore i+j
                    rectangularArray[i, j] = i + j;
                }
            }
            // report the contents of the array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine("rectangularArray[{0},{1}] = {2}",
                        i, j, rectangularArray[i, j]);
                }
            }
        }
    }
}