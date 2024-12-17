
namespace WorkingWithStrings
{
    public static class StringTester
    {
        static void Main()
        {
            // create some strings to work with
            string s1 = "abcd";
            string s2 = "ABCD";
            string s3 = @"Liberty Associates, Inc.
                        provides custom .NET development,
                        on-site Training and Consulting";
            int result; // hold the results of comparisons
                        
            result = string.Compare(s1, s2); //-1 poiche case sensitive
            Console.WriteLine(
            "compare s1: {0}, s2: {1}, result: {2}\n", s1, s2, result);
            // overloaded compare, takes boolean "ignore case"
            
            result = string.Compare(s1, s2, true);  //true indica di ignorare il case sensitive (0..)
            Console.WriteLine("compare insensitive\n");
            Console.WriteLine("s4: {0}, s2: {1}, result: {2}\n", s1, s2, result);
            // concatenation method
            string s6 = string.Concat(s1, s2);
            Console.WriteLine("s6 concatenated from s1 and s2: {0}", s6);
            // use the overloaded operator
            string s7 = s1 + s2;
            Console.WriteLine("s7 concatenated from s1 + s2: {0}", s7);
            // the string copy method
            string s8 = string.Copy(s7);
            Console.WriteLine("s8 copied from s7: {0}", s8);
            // use the overloaded operator
            string s9 = s8;
            Console.WriteLine("s9 = s8: {0}", s9);
            // three ways to compare.
            Console.WriteLine(
            "\nDoes s9.Equals(s8)?: {0}", s9.Equals(s8));
            Console.WriteLine("Does Equals(s9,s8)?: {0}", string.Equals(s9, s8));
            Console.WriteLine("Does s9==s8?: {0}", s9 == s8);
            // Two useful properties: the index and the length
            Console.WriteLine("\nString s9 is {0} characters long. ", s9.Length);
            Console.WriteLine("The 5th character is {0}\n", s9[4]);
            // test whether a string ends with a set of characters
            Console.WriteLine("s3:{0}\nEnds with Training?: {1}\n", s3,
            s3.EndsWith("Training"));
            Console.WriteLine("Ends with Consulting?: {0}",
            s3.EndsWith("Consulting"));
            // return the index of the substring
            Console.WriteLine("\nThe first occurrence of Training ");
            Console.WriteLine("in s3 is {0}\n", s3.IndexOf("Training"));
            // insert the word "excellent" before "training"
            string s10 = s3.Insert(101, "excellent ");
            Console.WriteLine("s10: {0}\n", s10);
            // you can combine the two as follows:
            string s11 = s3.Insert(s3.IndexOf("Training"), "excellent ");
            Console.WriteLine("s11: {0}\n", s11);
        }
    }
}


//es compare():
/*
string str1 = "apple";
string str2 = "banana";
int result = string.Compare(str1, str2);
Console.WriteLine(result); // Stampa un valore negativo, perché "apple" è lessicograficamente precedente a "banana"
*/