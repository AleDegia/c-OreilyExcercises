using System;
using System.Collections;

class Program
{
    static void Main()
    {
        ArrayList arrayList = new ArrayList();
        int myNumber = 10;
        int myNumber2 = myNumber;

        // Autoboxing: l'int viene automaticamente convertito in un oggetto
        arrayList.Add(myNumber);  // L'arrayList contiene ora un oggetto, non un int
        arrayList.Add(myNumber2);

        // Quando accedi al valore, devi fare il casting esplicito
        int retrievedNumber = (int)arrayList[0]; // Devi fare un cast per ottenere di nuovo un int

        Console.WriteLine(retrievedNumber);  // Stampa: 10

        int sum = 0;
        foreach (object obj in arrayList)
        {
            if(obj is int)
            {
                sum += Convert.ToInt32(obj);
            }
        }
        Console.WriteLine(sum); //20
    }
}


/*
ArrayList è una collezione non generica. Ciò significa che può contenere elementi di tipi diversi. 
Ogni elemento in un ArrayList è trattato come un tipo object, quindi può contenere qualsiasi tipo di dato.

Flessibilità: Puoi aggiungere numeri, stringhe, oggetti, ecc., in un ArrayList senza restrizioni di tipo.

Quando aggiungi un int (o qualsiasi tipo di valore) a un ArrayList, il valore viene automaticamente convertito (o "autoboxed") 
in un oggetto (object), poiché ArrayList è una collezione non generica che può contenere solo oggetti (object).

Ha i metodi: Add(value), Remove(value), DeleteAt(index)

*/