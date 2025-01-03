using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        // Predicate che verifica se un numero è maggiore di 3
        Predicate<int> isGreaterThanThree = x => x > 3;

        // Troviamo il primo numero maggiore di 3
        int firstGreaterThanThree = numbers.Find(isGreaterThanThree);

        Console.WriteLine(firstGreaterThanThree);  // Output: 4
    }
}



/*
 * Un Delegate in C# è un tipo di dato che rappresenta un riferimento a un metodo. 
 * Può essere visto come un tipo sicuro di puntatore a funzione. Un delegate consente di invocare metodi in modo indiretto, 
 * senza sapere esattamente quale metodo verrà chiamato in quel momento.

Generico: Un Delegate può rappresentare qualsiasi metodo, indipendentemente dalla sua firma, purché la firma corrisponda a quella del delegato. 
Ad esempio, un Delegate può rappresentare un metodo che non accetta parametri e restituisce un void, oppure un metodo che prende dei parametri e restituisce un valore.


public delegate void MyDelegate(string message);

class Program
{
    static void MyMethod(string msg)
    {
        Console.WriteLine(msg);
    }

    static void Main()
    {
        MyDelegate del = MyMethod;  // Assegna il metodo al delegate
        del("Hello, World!");  // Invoca il metodo tramite il delegate
    }
}




Predicate

Un Predicate<T> è un tipo di delegate generico già definito in .NET, progettato specificamente per rappresentare un metodo che accetta un parametro di tipo T e restituisce un valore booleano (bool), utilizzato per testare o verificare una condizione.
Predicate<T>: È una specializzazione di Delegate<T>, con la firma fissa che restituisce un bool e accetta un parametro di tipo T.

La principale differenza tra un Predicate<T> e un Delegate generico è che il Predicate<T> è specializzato per una specifica situazione: la verifica di una condizione su un tipo T. 


La sintassi per dichiarare un Predicate<T> è la seguente:

public delegate bool Predicate<T>(T obj);


- Il metodo che rappresenta un Predicate<T> deve sempre restituire un valore bool.
- Viene spesso utilizzato in metodi come Find, FindAll, RemoveAll, e simili, dove è necessario specificare una condizione da soddisfare.

Sintassi del metodo Find: List<T>.Find(Predicate<T>)

quando chiami numbers.Find(isGreaterThanThree);, il Predicate<int> (che nel tuo caso è rappresentato dalla variabile isGreaterThanThree) viene eseguito subito per trovare il primo elemento che soddisfa la condizione specificata.
Inoltre Find restituisce il primo elemento della lista per cui il predicato restituisce true.
Se nessun elemento soddisfa la condizione, Find restituirà il valore predefinito per il tipo di dato (ad esempio, null per i tipi di riferimento e 0 per i tipi numerici come int).
*/