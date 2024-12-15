using System;
using System.Collections.Generic;
using System.Text;
namespace SimpleIndexer
{
    // a simplified ListBox control
    public class ListBoxTest
    {
        private string[] strings;
        private int ctr = 0;
        // initialize the listbox with strings
        public ListBoxTest(params string[] initialStrings)  //accetta numero variabile di stringhe
        {
            // allocate space for the strings
            strings = new String[256];
            // copy the strings passed in to the constructor
            foreach (string s in initialStrings)
            {
                strings[ctr++] = s;
            }
        }
        // add a single string to the end of the listbox
        public void Add(string theString)
        {
            if (ctr >= strings.Length)
            {
                // handle bad index
            }
            else
                strings[ctr++] = theString;
        }
        // permette di accedere all'oggett (this) tramite l'indice
        public string this[int index]
        {
            get     // Viene eseguito quando si accede a un valore con la notazione oggetto[indice].
            {
                if (index < 0 || index >= strings.Length)
                {
                    // handle bad index
                }
                return strings[index];
            }
            set
            {
                // add only through the add method
                if (index >= ctr)
                {
                    // handle error
                }
                else
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
            // create a new listbox and initialize
            ListBoxTest lbt =
            new ListBoxTest("Hello", "World");
            // add a few strings
            lbt.Add("Who");
            lbt.Add("Is");
            lbt.Add("Douglas");
            lbt.Add("Adams");
            
            string subst = "Universe";
            lbt[1] = subst;     //uso indexer

            // access all the strings
            for (int i = 0; i < lbt.GetNumEntries(); i++)
            {
                Console.WriteLine("lbt[{0}]: {1}", i, lbt[i]);
            }
        }
    }
}

/*
 Gli indexers ti permettono di accedere ai membri di un oggetto utilizzando la notazione delle parentesi quadre [], 
anziché dover chiamare esplicitamente metodi o proprietà.

Usando l'indexer, alal posizione lbt[1] troveremo "Universe" invece che "World"
*/