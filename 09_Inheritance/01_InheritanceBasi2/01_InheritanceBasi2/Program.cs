using System;
namespace InheritanceDemo
{
    class A
    {
        public int x;
        public int y;
        public A()
        {
            Console.WriteLine("Class A Constructor is Called");
        }
        public void Method1()
        {
            Console.WriteLine("Method 1");
        }
        public void Method2()
        {
            Console.WriteLine("Method 2");
        }
    }
    class B : A
    {
        public B()
        {
            int result = x + y;
            Console.WriteLine("Class B Constructor is Called");
            Console.WriteLine(result);      //da 0 ma non da errore
        }
        public void Method3()
        {
            Console.WriteLine("Method 3");
        }
        static void Main()
        {
            A obj;      //reference (non ha memory allocation, è un puntatore)
            B b = new B();      //istanza
            obj = b;

            obj.Method1();
            obj.Method2();
            obj.Method3();      //da errore 
            Console.ReadKey();
        }
    }
}

/*
Riferimento obj di tipo A: Nel codice, la variabile obj è dichiarata come A, quindi il compilatore considera obj come un 
oggetto della classe A. Quando si scrive obj.Method3();, il compilatore cerca il metodo Method3() all'interno della 
classe A, ma questo metodo non esiste in A. La classe A ha solo Method1() e Method2(), quindi non viene trovato Method3().

In C#, quando usi un riferimento di tipo A (come obj), puoi chiamare solo i metodi che sono definiti nella classe A o 
che sono stati ridefiniti in classi derivate tramite il polimorfismo (override). 

// Per chiamare Method3, bisogna fare il cast esplicito a B:
   ((B)obj).Method3();      

IMPO -> perciò il poliformismo si attua sempre e solo con l'override dei metodi della classe base.
Quando usi il polimorfismo con i metodi, il comportamento che viene eseguito dipende dal tipo effettivo dell'oggetto 
(e non dal tipo del riferimento), grazie alla possibilità di sovrascrivere i metodi nelle classi derivate.


IMPO -> Le variabili (o campi) non possono essere sovrascritte in C#. Tuttavia, le classi derivate possono nascondere
una variabile della classe base con una variabile con lo stesso nome usando la parola chiave new.

class B : A
    {
        public new int x = 20;  // Variabile nella classe derivata, nasconde quella della base
    }

Quando creiamo un oggetto di tipo B, ma lo trattiamo come un riferimento di tipo A come  A obj2 = new B();
vediamo comunque 10 per x, poiché A sta usando il suo campo x originale. Anche se l'oggetto è di tipo B, 
il riferimento è di tipo A e quindi la variabile di A è quella che viene usata.
Quando in una classe derivata definisci un campo con lo stesso nome di un campo nella classe base, 
C# non usa il polimorfismo per decidere quale campo utilizzare (come farebbe con i metodi). 
Invece, il comportamento è determinato dal tipo di riferimento e non dal tipo dell'oggetto effettivo.

In C#, i campi non sono polimorfici. Questo significa che:
Il campo a cui si accede dipende dal tipo di riferimento, non dal tipo effettivo dell'oggetto.

*/