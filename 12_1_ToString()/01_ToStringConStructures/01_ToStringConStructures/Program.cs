using System;
namespace CreatingAStruct
{
    public struct Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return (String.Format("{0}, {1}", X, Y));
        }
    }
    public class Tester
    {
        public void myFunc(Location loc)
        {
            loc.X = 50;
            loc.Y = 100;
            Console.WriteLine("In MyFunc loc: {0}", loc);
        }
        static void Main()
        {
            Location loc1 = new Location();
            loc1.X = 200;
            loc1.Y = 300;
            Console.WriteLine("Loc1 location: {0}", loc1);      //Loc1 location: 200, 300
            Tester t = new Tester();
            t.myFunc(loc1);                                     //In MyFunc loc: 50, 100
            Console.WriteLine("Loc1 location: {0}", loc1);
        }
    }
}


/*
 * In C#, quando passi un oggetto (o una struttura) come argomento a Console.WriteLine, il metodo:

Verifica il tipo del parametro:

Se è un oggetto o un valore complesso (come una struttura), chiama implicitamente il metodo ToString() 
per ottenere una rappresentazione testuale.

Se non sovrascrivi ToString in una classe o una struttura, la sua implementazione predefinita (fornita da System.Object) verrà usata.
Per le strutture, la versione predefinita di ToString restituisce il nome completo del tipo, ad esempio: NamespaceName.StructName.

Cosa succede con una sovrascrittura:
Quando sovrascrivi ToString, come nel tuo esempio, la tua implementazione personalizzata viene chiamata automaticamente.

quando utilizzi Console.WriteLine con un oggetto che non sovrascrive il metodo ToString(), viene chiamata 
l'implementazione predefinita di ToString() definita nella classe Object. 
Questa implementazione restituisce il nome del tipo completo (namespace incluso) e l'hash code dell'oggetto, 
che può essere interpretato come un identificatore o un riferimento.

La versione predefinita del metodo ToString() della classe Object restituisce una stringa nel formato:

Namespace.ClassName@HashCode

percio grazie al ToString() qualsiasi console.writeline fatto sull'oggetto di classe Location va a eseguire il TOString()
*/
