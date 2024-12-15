using _01_Destructors;

class Program
{
    static void Main(string[] args)
    {
        DestructorDemo obj1 = new DestructorDemo();
        DestructorDemo obj2 = new DestructorDemo();

        //making obj1 ready for garbage collection
        obj1 = null; 
        //GC.Collect();  ->  con questo attivo faccio richiesta manuale al gc di distruggere gli unused objects
        Console.ReadKey();
    }
}

//Output:
//Constructor object created
//Constructor object created


/*
                                                    Spiegazione:


In C#, il distruttore (simbolo ~) viene chiamato automaticamente dal Garbage Collector (GC) quando un oggetto non è più accessibile e il sistema decide di liberare la memoria allocata da quell'oggetto. Tuttavia, il momento esatto in cui il distruttore viene invocato non è deterministico.

Dettagli sul funzionamento:
Oggetto reso non raggiungibile:

Quando assegni un oggetto a null o esci dal suo ambito e non ci sono più riferimenti attivi all'oggetto, esso diventa eleggibile per il Garbage Collector.
GC eseguito:

Il Garbage Collector non opera immediatamente. Decide di liberare memoria solo quando:
Il sistema è sotto pressione di memoria.
Si verifica un'operazione che innesca una raccolta.
*/