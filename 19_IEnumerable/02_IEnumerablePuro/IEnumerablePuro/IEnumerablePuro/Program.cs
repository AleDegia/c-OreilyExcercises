using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello world");

        var array = new int[] { 1, 2, 3 };

        array.GetEnumerator();

        //es di enumeratore interno
        foreach (var a in array)
        {
            Console.WriteLine($"A is {a}");
        }

        //es enumeratore esterno per iterare manualmente
        var enumerator = array.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine($"Enumerato A is {enumerator.Current}");
        }

        var infiniteEnumerable = new MyInfiniteEnumerable();
        enumerator = infiniteEnumerable.GetEnumerator();

        foreach( var i in infiniteEnumerable)
        {
            Console.WriteLine($"I is {i}");
        }

    }
}

//Quando una classe implementa l'interfaccia IEnumerable<int>, essa si comporta come una collezione
//che può essere iterata
public class MyInfiniteEnumerable : IEnumerable<int>
{
    public IEnumerator GetEnumerator()
    {
        return new MyInfiniteEnumerator();
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        return new MyInfiniteEnumerator();
    }
}

public class MyInfiniteEnumerator: IEnumerator<int>
{
    public int Current { get; private set; } = 0;

    object IEnumerator.Current => Current;
    public void Dispose()
    { }

    public bool MoveNext()
    {
        Current++;
        return true;
    }

    public void Reset()
    {
        Current = 0;
    }
}

/*
 * Implementando IEnumerable in MYInfiniteEnumerable, questo caso, non devi preoccuparti di creare un ciclo, gestire l'indice, o ottenere l'elemento successivo. L'interfaccia IEnumerable<int> fornisce un modo semplice e leggibile per iterare attraverso la sequenza.
*/