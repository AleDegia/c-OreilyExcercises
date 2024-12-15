namespace _01_DestructorsPart2;

public class First
{
    public int x = 10;
    public First() 
    {
        Console.WriteLine("Costruttore di First");
    }
    ~First()
    {
        Console.WriteLine("Descrutor of First called");
    }
}

public class Second : First
{
    public int y = 20;
    public Second() 
    {
        Console.WriteLine("Costruttore di second");
    }
    ~Second()
    {
        Console.WriteLine("Descrutor of Second called");
    }
}

public class Third : Second
{
    public int z = 30;
    public Third() 
    {
        Console.WriteLine("Costruttore di Third");
    }
    ~Third()
    {
        Console.WriteLine("Descrutor of Third called");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Third obj = new Third();
        Console.WriteLine($"x: {obj.x}, y: {obj.y}, z: {obj.z}");
        obj = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // Ritardo per garantire che il garbage collector possa fare il suo lavoro
        System.Threading.Thread.Sleep(1000); // Pausa di 1 secondo

    }
}

/*
Output:

Costruttore di First
Costruttore di Second
Costruttore di Third
x: 10, y: 20, z: 30
Descrutor of Third called
Descrutor of Second called
Descrutor of First called
*/


/*
 Quando crei l'oggetto Third, viene attivato il costruttore di Third, che a sua volta attiva il costruttore 
della sua classe base Second, e poi quello della classe base First.
Dopo che il costruttore di First è stato eseguito, il costruttore di Second viene chiamato e cosi via.
Dopo che l'oggetto Third è stato creato, i valori degli attributi (ereditati da First e Second) vengono stampati
(In C#, quando una classe derivata crea un'istanza di un oggetto, può accedere ai membri (campi, proprietà, metodi) 
della classe base (padre), a meno che questi membri non siano privati.)
GC.Collect() chiama il Garbage Collector che chiama i distruttori.
*/


/*
 * il destructor esegue il codice tra parentesi graffe come try e ha un finally che mi rimanda poi al 
 * destructor della parent class.
 * QUa viene perciò eseguito il Destructor della class Third per primo, poichè una sua istanza non ha reference, 
 * e poi viene chiamato il Destructor della parent class (Second) e a sua volta quello del suo parent (First) e poi 
 * quello dell classe Object.
 * Even though you create an object of Third, it inherits all the members (and potentially resources) from Second and First.
    If Second or First have resources or logic to clean up, their destructors need to be executed.

First, the destructor of Third.
Then, the destructor of Second.
Finally, the destructor of First.

Il distruttore di Second non distrugge direttamente qualcosa di specifico in questo esempio, perché la classe Second 
non possiede risorse esplicite da liberare. Tuttavia, il distruttore viene comunque chiamato.
La verifica delle unused resources avviene percio solo per la chiamata del primo distruttore in una gerarchia.

IMPO -> ognivolta che creo un oggetto di una child class, internamente viene chiamato il costruttore della parent class.
Le eventuali variabili delle classi parent vengono inizializzate quando viene attivato il loro costruttore.
Coi distruttori è uguale solo che i distruttori vengono chiamati a partire dalla child class, i costruttori partono 
dalla parent class..

IMPO -> La chiamata a GC.Collect() e GC.WaitForPendingFinalizers() può forzare il garbage collector a eseguire 
la finalizzazione, ma il comportamento non è sempre prevedibile al 100%. Inoltre, la stampa dell'output potrebbe 
non essere visibile se il thread principale termina prima che il garbage collector abbia il tempo di eseguire i 
distruttori.
Dopo aver chiamato GC.Collect() e GC.WaitForPendingFinalizers(), inserisci un piccolo ritardo per consentire al 
garbage collector di fare il suo lavoro.
Se non vedi ancora i distruttori, è probabile che il garbage collector stia ottimizzando la memoria in modo tale che 
gli oggetti non vengano mai effettivamente distrutti. In questo caso, puoi considerare l'uso di IDisposable


Perchè i costruttori partono dalla classe base?

La logica dei costruttori:
Quando crei un oggetto, la logica è tale che le classi base devono essere inizializzate prima della classe derivata. 
Questo è necessario per garantire che le proprietà e i comportamenti della classe base siano correttamente configurati 
prima che la classe derivata possa aggiungere o modificare il comportamento dell'oggetto.
Quando crei un oggetto di una classe derivata, il sistema deve inizializzare prima tutte le proprietà e i membri della 
classe base, perché la classe derivata potrebbe dipendere da di essi.


Perché i distruttori partono dalla classe derivata?

La classe derivata potrebbe aver modificato o aggiunto risorse che devono essere rilasciate per prime, e solo dopo 
si può passare alla pulizia della classe base. In altre parole, prima vengono distrutti i componenti aggiuntivi della 
classe derivata e solo dopo i componenti della classe base.

La classe derivata potrebbe fare affidamento su alcuni membri della classe base per gestire correttamente le sue risorse.
Se la classe base viene distrutta prima, i membri della classe base non saranno più accessibili quando il distruttore
della classe derivata verrà eseguito, e la derivata non sarà in grado di liberare correttamente le sue risorse.

 */