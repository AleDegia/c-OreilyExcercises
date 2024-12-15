using System;
namespace Inheriting_From_Object
{
    public class SomeClass
    {
        private int val;
        public SomeClass(int someVal)
        {
            val = someVal;
        }

        //sovrascrivo metodo ToString() della classe base object
        public override string ToString()   
        {
            //ritorna il valore della variabile val sottoforma di stringa
            return val.ToString();     
        }
    }
    class Program
    {
        static void DisplayValue(object o)
        {
            Console.WriteLine(
                "The value of the object passed in is {0}", o);
        }
        static void Main(string[] args)
        {
            int i = 5;
            //Anche se int è un tipo valore, può comunque chiamare metodi senza autoboxing. Perchè??
            //Perchcè non viene ritornato val qui ??  l'override di ToString() dovrebbe ritornare val..
            Console.WriteLine("The value of i is: {0}", i.ToString());    
            DisplayValue(i);    //autoboxing   
            SomeClass s = new SomeClass(7);
            Console.WriteLine("The value of s is {0}", s.ToString());
            DisplayValue(s);
        }
    }
}

/*
 * Se passiamo un intero (int), il suo valore verrà stampato come stringa.
Se passiamo un oggetto SomeClass, verrà chiamato il metodo ToString() che abbiamo sovrascritto, 
e verrà stampato il valore di val.

Anche se i è un tipo valore (int), C# lo "autoboxerà" in un oggetto di tipo Int32 
(che è la rappresentazione dell'intero in C#) e quindi può invocare il metodo ToString() di Int32.
Il valore i viene trattato come un oggetto temporaneo per permettere la chiamata al metodo.

L'autoboxing è un meccanismo in C# (e in altre lingue come Java) che consente di convertire automaticamente un tipo valore 
(come int, double, bool) in un tipo riferimento (un oggetto). Questo avviene quando un tipo valore viene assegnato a 
una variabile di tipo object o quando viene passato come parametro a un metodo che si aspetta un tipo di riferimento.

Autoboxing es:

int i = 42;
object obj = i;  // Autoboxing: 'i' viene trasformato in un oggetto di tipo Int32
Console.WriteLine(obj.ToString());  // Chiamata al metodo ToString() sull'oggetto
*/