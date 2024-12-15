namespace Queue
{
    public class Tester
    {
        static void Main()
        {
            //first-in, first-out
            Queue<Int32> intQueue = new Queue<Int32>();
            // populate the array
            for (int i = 0; i < 5; i++)
            {
                intQueue.Enqueue(i * 5);
            }
            // Display the Queue.
            Console.Write("intQueue values:\t");
            PrintValues(intQueue);
            // Remove an element from the queue.
            Console.WriteLine(
            "\n(Dequeue)\t{0}", intQueue.Dequeue());    //leva il primo elemento che ho inserito con Enqueue..
            // Display the Queue.
            Console.Write("intQueue values:\t");
            PrintValues(intQueue);
            // Remove another element from the queue.
            Console.WriteLine(
            "\n(Dequeue)\t{0}", intQueue.Dequeue());    //leva il secondo inserito
            // Display the Queue.
            Console.Write("intQueue values:\t");
            PrintValues(intQueue);
            // View the first element in the
            // Queue but do not remove.
            Console.WriteLine(
            "\n(Peek) \t{0}", intQueue.Peek());
            // Display the Queue.
            Console.Write("intQueue values:\t");
            PrintValues(intQueue);
        }

        //il metodo prende un parametro di tipo IEnumerable<int>, quindi va bene ogni oggetto che implementi l'interfaccia
        public static void PrintValues(IEnumerable<Int32> myCollection)
        {
            //uso metodo GetEnumerator che restituisce un oggetto che permette di scorrere gli elementi 1 a 1
            IEnumerator<Int32> myEnumerator = myCollection.GetEnumerator();
            while (myEnumerator.MoveNext()) //finche c'è un elemento alla posizione successiva
                Console.Write("{0} ", myEnumerator.Current);
            Console.WriteLine();
        }
    }
}

/*
Il metodo PrintValues prende un parametro di tipo IEnumerable<Int32> per una questione di flessibilità e 
compatibilità con diversi tipi di collezioni in C#.

IMPO -> non posso passare direttamente un interfaccia come parametro ma è sottointeso che debba essere un oggetto 
di una classe che implementa l'interfaccia

Quando chiami GetEnumerator(), l'enumeratore è inizialmente posizionato prima del primo elemento della collezione. 
La prima chiamata a MoveNext() sposta l'enumeratore al primo elemento, e ogni successiva chiamata sposta l'enumeratore 
al prossimo elemento.



*/