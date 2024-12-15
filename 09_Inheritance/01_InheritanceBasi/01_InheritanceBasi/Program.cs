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
            B obj = new B();    //viene chiamato il parent constructor di default
            obj.Method1();
            obj.Method2();
            obj.Method3();
            Console.ReadKey();
        }
    }
}

/*
 Output:

Class A Constructor is Called
Class B Constructor is Called
0
Method 1
Method 2
Method 3


Le variabili della classe padre devono essere inizializzate. Quando vengono inizializzate? 
Quando viene eseguito il suo costruttore. La classe figlia, se non venissero inizializzate, 
quando faccio  int result = x + y;  riceverebbe un errore.

Quando viene creato un oggetto della classe figlia, prima che il costruttore della classe figlia venga eseguito, 
il costruttore della classe padre viene invocato (a meno che non sia specificato diversamente).
Questo accade per garantire che tutte le variabili e le risorse della classe padre siano correttamente 
inizializzate prima di essere utilizzate dalla classe figlia.

Il costruttore della classe padre deve percio essere public e non private, senno non posso accederci per 
inizializzare le sue variabili e poi ereditarle.

In alcuni linguaggi (come Java), se la classe padre ha un costruttore che accetta parametri e tu non lo chiami 
esplicitamente nel costruttore della classe figlia, riceverai un errore, in quanto Java tenterà di invocare un 
costruttore di default che potrebbe non esistere.

*/