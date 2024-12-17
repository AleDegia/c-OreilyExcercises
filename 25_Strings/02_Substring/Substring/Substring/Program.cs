
namespace SubString
{
    public class StringTester
    {
        static void Main()
        {
            // create some strings to work with
            string s1 = "One Two Three Four";
            int ix;
            // get the index of the last space
            ix = s1.LastIndexOf(" ");
            // get the last word (la parola a quell'indice, cioè four)
            string s2 = s1.Substring(ix + 1);
            // mette in s1 tutto da 0 fino al carattere prima dell'inizio dell'ultima parola (percio leva four)
            s1 = s1.Substring(0, ix);
            // find the last space in s1 (after 'two')
            ix = s1.LastIndexOf(" ");
            //reset ix to the space after "two" plus one more
            // thus s3 = "three"
            string s3 = s1.Substring(ix + 1);
            
            s1 = s1.Substring(0, ix);  //'one two'
            // reset ix to the space between
            // "one" and "two"
            ix = s1.LastIndexOf(" ");
            // set s4 to the substring starting one
            // space after ix, thus the substring "two"
            string s4 = s1.Substring(ix + 1);
            // reset s1 to the substring starting at 0
            // and ending at ix, thus "one"
            s1 = s1.Substring(0, ix);
            // set ix to the last space, but there is
            // none, so ix now = -1
            ix = s1.LastIndexOf(" ");
            // set s5 to the substring at one past
            // the last space. There was no last space
            // so this sets s5 to the substring starting
            // at zero
            string s5 = s1.Substring(ix + 1);
            Console.WriteLine("s2: {0}\ns3: {1}", s2, s3);
            Console.WriteLine("s4: {0}\ns5: {1}\n", s4, s5);
            Console.WriteLine("s1: {0}\n", s1);
        }
    }
}
