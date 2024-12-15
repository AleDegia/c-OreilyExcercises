using System;
using System.Collections.Generic;
using System.Text;
namespace OverloadedIndexer
{
    // a simplified ListBox control
    public class ListBoxTest
    {
        private string[] strings;
        private int ctr = 0;
        // initialize the listbox with strings
        public ListBoxTest(params string[] initialStrings)
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

        //se trova la stringa ritorna il suo indice sennò -1
        private int findString(string searchString)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].StartsWith(searchString))
                {
                    return i;
                }
            }
            return -1;
        }

        // indexer con stringa come index
        public string this[string index]
        {
            get
            {
                if (index.Length == 0)
                {
                    // handle bad index
                }
                //cerca una stringa precisa e ritorna l'indice
                return this[findString(index)];
            }
            set
            {
                //trova la stringa con index restituito da findString nell'array Strings e passa value
                strings[findString(index)] = value;
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
            ListBoxTest lbt = new ListBoxTest("Hello", "World");

            lbt.Add("Who");
            lbt.Add("Is");
            lbt.Add("Douglas");
            lbt.Add("Adams");
            
            string subst = "Universe";
            lbt[1] = subst;
            lbt["Hel"] = "GoodBye";     //passo stringa come index all'indexer (cella a indice 0 prende val GoodBye)
            // lbt["xyz"] = "oops";
            // access all the strings
            for (int i = 0; i < lbt.GetNumEntries(); i++)
            {
                Console.WriteLine("lbt[{0}]: {1}", i, lbt[i]);
            } // end for
        } // end main
    } // end tester
}