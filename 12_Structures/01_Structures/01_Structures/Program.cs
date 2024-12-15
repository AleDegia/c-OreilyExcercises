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
        public void myFunc(Location loc)    //passo per copia (con ogg non struct sarebbe x valore anche senza ref e out)
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
            Console.WriteLine("Loc1 location: {0}", loc1);      //Loc1 location: 200, 300
        }
    }
}


/*
 
 Location loc1 = new Location(200,300);

 Then WriteLine() is called:
 Console.WriteLine("Loc1 location: {0}", loc1);

  WriteLine() is expecting an object, but of course, Location is a struct (a value type).
 The compiler automatically wraps the struct in an object, a process called boxing (as
 it would any value type), and it is the boxed object that is passed to WriteLine().+

Il boxing in C# è il processo in cui un valore di tipo valore (come un tipo struct, int, bool, ecc.) viene impacchettato 
in un oggetto di tipo riferimento (ad esempio, nella classe base object). 
Questo processo consente di trattare i tipi valore come oggetti.
Quando un valore viene boxed, viene allocata una nuova istanza sul heap per contenere il valore. 
Questo valore viene copiato all'interno di questa istanza e un riferimento a essa viene restituito.

 
 Le struct in C# (strutture) sono un tipo di dato che si comporta come un tipo valore anziché come un tipo 
reference (come le classi). 
- Le struct vengono allocate nello stack (quando non fanno parte di un oggetto) e non nel heap come le classi.
- Vengono copiate quando vengono passate come argomenti a un metodo o assegnate a un'altra variabile.
- Non possono avere costruttori senza parametri definiti dall'utente:
Ogni struct ha un costruttore predefinito (che inizializza i campi a valori predefiniti, come 0 per numeri e null per reference), ma non è possibile definirne uno senza parametri personalizzato.
- non possono ereditare altre classi o essere ereditate, ma possono implementare interfacce
- non possono essere null a meno che non vengano dichiarate come nullable
- possono contenere: campi, metodi, propiretà ,eventi, ecc
- You create an instance of a struct by using the new keyword in an assignment state
ment, just as you would for a class.

IMPO -> servono come contenitori di valori costanti.
Se un oggetto deve essere complesso, modificabile, o condiviso tra più parti del codice, è meglio usare una classe.
*/
