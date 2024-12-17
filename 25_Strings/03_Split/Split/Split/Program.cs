
namespace StringSplit
{
    public class StringTester
    {
        static void Main()
        {
            // create some strings to work with
            string s1 = "One,Two,Three Liberty Associates, Inc.";
            // constants for the space and comma characters
            const char Space = ' ';
            const char Comma = ',';
            // array of delimiters to split the sentence with
            char[] delimiters = new char[] { Space, Comma };
            string output = "";
            int ctr = 1;
            // split the string and then iterate over the
            // resulting array of strings
            foreach (string subString in s1.Split(delimiters))
            {
                output += ctr++;
                output += ": ";
                output += subString;
                output += "\n";
            }
            Console.WriteLine(output);
        }
    }
}

/*
 * split usa 2 delimitatori,
 * percio  la stringa sarà divisa ogni volta che uno di questi caratteri viene trovato.
 * 
output:
1: One
2: Two
3: Three
4: Liberty
5: Associates
6:
7: Inc.
*/