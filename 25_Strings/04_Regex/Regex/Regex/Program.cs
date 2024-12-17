
using System.Text;
using System.Text.RegularExpressions;
namespace UsingRegEx
{
    public class Tester
    {
        static void Main()
        {
            string s1 = "One,Two,Three Liberty Associates, Inc.";
            Regex theRegex = new Regex(" |, |,");   //3 delimiters: spazio ; virgola e spazio ; virgola
            StringBuilder sBuilder = new StringBuilder();  
            int id = 1;
            foreach (string subString in theRegex.Split(s1))
            {
                //parametro 1 è l'indice, il 2 è la stringa
                sBuilder.AppendFormat("{0}: {1}\n", id++, subString);
            }
        Console.WriteLine("{0}", sBuilder);
        }
    }
}

/*
 * string, che è immutabile (cioè ogni volta che si modifica una stringa, viene creata una nuova istanza
 * StringBuilder permette di concatenare, modificare o manipolare le stringhe
 * è fatto apposta per costruire la stringa di output, aggiungendo progressivamente indice e sottostringa corrispondente.
*/