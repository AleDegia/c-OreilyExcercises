using System;
using System.Collections.Generic;
using System.Text;
namespace JaggedArray
{
    public class Tester
    {
        static void Main()
        {
            const int rows = 4;
            // declare the jagged array as 4 rows high
            int[][] jaggedArray = new int[rows][];
            // the first row has 5 elements
            jaggedArray[0] = new int[5];
            // a row with 2 elements
            jaggedArray[1] = new int[2];
            // a row with 3 elements
            jaggedArray[2] = new int[3];
            // the last row has 5 elements
            jaggedArray[3] = new int[5];
            // Fill some (but not all) elements of the rows
            jaggedArray[0][3] = 15;
            jaggedArray[1][1] = 12;
            jaggedArray[2][1] = 9;
            jaggedArray[2][2] = 99;
            jaggedArray[3][0] = 10;
            jaggedArray[3][1] = 11;
            jaggedArray[3][2] = 12;
            jaggedArray[3][3] = 13;
            jaggedArray[3][4] = 14;

            //stampa prima riga 
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("jaggedArray[0][{0}] = {1}",      
                    i, jaggedArray[0][i]);      //0 0 15 0 0
            }

            //seconda
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("jaggedArray[1][{0}] = {1}",
                    i, jaggedArray[1][i]);
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("jaggedArray[2][{0}] = {1}",
                   i, jaggedArray[2][i]);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("jaggedArray[3][{0}] = {1}",
                    i, jaggedArray[3][i]);
            }
        }
    }
}

/*
 * A jagged array is an array of arrays. It is called “jagged” because each row need not
 be the same size as all the others.

  In a jagged array, each dimension is a one-dimensional array.

You access the fifth element of the third array by writing myJaggedArray[2][4].

*/