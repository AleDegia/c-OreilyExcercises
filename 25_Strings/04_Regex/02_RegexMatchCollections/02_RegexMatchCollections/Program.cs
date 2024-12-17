
using System.Text.RegularExpressions;
namespace UsingMatchCollection
{
    class Test
    {
        public static void Main()
        {
            string string1 = "This is a test string";
            // find any nonwhitespace followed by whitespace
            Regex theReg = new Regex(@"(\S+)\s");
            // get the collection of matches
            MatchCollection theMatches = theReg.Matches(string1);
            // iterate through the collection
            foreach (Match theMatch in theMatches)
            {
                Console.WriteLine("theMatch.Length: {0}",
                theMatch.Length);
                if (theMatch.Length != 0)
                {
                    Console.WriteLine("theMatch: {0}",
                    theMatch.ToString());
                }
            }
        }
    }
}

/*
 The string \S cerca i caratteri che non sono spazi, and the plus sign indicates one or more. (cercherà una seq di 1 o + caratteri non spazio)
 The string \s (note lowercase) indicates whitespace. 
Thus, together, this string looks for any nonwhitespace characters followed by whitespace.
*/