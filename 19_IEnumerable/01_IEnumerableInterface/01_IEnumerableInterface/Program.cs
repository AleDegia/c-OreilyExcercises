using Enumerable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
namespace Enumerable
{
    public class ListBoxTest : IEnumerable<string>
    {
        private string[] strings;
        private int ctr = 0;
        // Rende la classe Enumerabile: puoi iterare sugli elementi della classe come se fosse una collezione
        public IEnumerator<string> GetEnumerator()      //chiamato dal foreach du oggetto che implementa IEnumerable
        {
            foreach (string s in strings)
            {
                yield return s; //Restituisce ogni stringa una alla volta.
            }
        }
        // Explicit interface implementation.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        //costruttore (inizializza array)
        public ListBoxTest(params string[] initialStrings)
        {
            // allocate space for the strings
            strings = new String[8];
            // copy the strings passed in to the constructor
            foreach (string s in initialStrings)
            {
                strings[ctr++] = s;
            }
        }
        // Aggiunge una nuova stringa all'array strings e incrementa il contatore ctr.
        public void Add(string theString)
        {
            strings[ctr] = theString;
            ctr++;
        }
        // allow array-like access
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= strings.Length)
                {
                    // handle bad index
                }
                return strings[index];
            }
            set
            {
                strings[index] = value;

            }
        }

        // publish how many strings you hold
        public int GetNumEntries()
        {
            return ctr;
        }
    }
    public class Tester
    {
        static void Main()
        {
            // create oggetto ListBoxTest (non è un array.. chiama il costruttore)
            ListBoxTest lbt = new ListBoxTest("Hello", "World");
            // add a few strings
            lbt.Add("Who");
            lbt.Add("Is");
            lbt.Add("Douglas");
            lbt.Add("Adams");
            // test the access
            string subst = "Universe";
            lbt[1] = subst;

            // posso farlo grazie a IEnumerable
            foreach (string s in lbt)
            {
                Console.WriteLine("Value: {0}", s);
            }
        }
    }
}


/*
Un ciclo foreach può essere utilizzato solo su oggetti che:

Implementano IEnumerable o IEnumerable<T>.
Forniscono un metodo GetEnumerator che restituisce un oggetto IEnumerator o IEnumerator<T>.

Se strings è un array (ad esempio, string[]), puoi usare foreach direttamente, perché gli array in C# 
implementano IEnumerable. Con IEnumerable<string> posso iterare attraverso una collezione di tipo string.

Il funzionamento di foreach:

Quando il compilatore incontra un foreach, lo traduce in un'operazione che:
Chiama il metodo GetEnumerator() sull'oggetto (initialStrings in questo caso).
Usa l'enumeratore per iterare su tutti gli elementi.

Come faccio a iterare su un oggetto?
lbt è un oggetto della classe ListBoxTest, che contiene un array di stringhe (l'array strings). 
Quando usi un ciclo foreach su lbt Stai effettivamente iterando sugli elementi contenuti nell'array strings.
Questo funziona perché la classe ListBoxTest implementa l'interfaccia IEnumerable<string>. 
In altre parole, la classe ListBoxTest ha un metodo GetEnumerator() che restituisce un oggetto di tipo IEnumerator<string>.
Questo metodo è ciò che permette di iterare sugli elementi della classe come se fosse una collezione.


Utilità:

se un giorno decidessi di cambiare l'array di stringhe (strings) in un'altra struttura dati (ad esempio, una lista o 
un database), non dovresti modificare il codice che usa la classe. 
Basta modificare ListBoxTest in modo che restituisca lo stesso tipo di dati tramite GetEnumerator().
Implementando IEnumerable, puoi anche aggiungere facilmente altre funzionalità in futuro, come: filtraccio, ecc
*/
