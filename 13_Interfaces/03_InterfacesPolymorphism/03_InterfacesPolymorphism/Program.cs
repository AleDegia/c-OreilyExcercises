using System;
namespace ExtendAndCombineInterface
{
    interface IStorable
    {
        void Read();
        void Write(object obj);
        int Status { get; set; }
    }
    // here's the new interface
    interface ICompressible
    {
        void Compress();
        void Decompress();
    }
    // Extend the interface
    interface ILoggedCompressible : ICompressible
    {
        void LogSavedBytes();
    }
    // Combine Interfaces
    interface IStorableCompressible : IStorable, ILoggedCompressible
    {
        void LogOriginalSize();
    }
    // yet another interface
    interface IEncryptable
    {
        void Encrypt();
        void Decrypt();
    }
    public abstract class Document { }

    //BigDocument eredita sia classe astratta che interfacce (tutte)
    public class BigDocument : Document, IStorableCompressible, IEncryptable
    {
        // hold the data for IStorable's Status property
        private int status = 0;
        // the document constructor
        public BigDocument(string s)
        {
            Console.WriteLine("Creating document with: {0}", s);
        }
        // implement IStorable
        public void Read()
        {
            Console.WriteLine(
            "Implementing the Read Method for IStorable");
        }
        public void Write(object o)
        {
            Console.WriteLine(
            "Implementing the Write Method for IStorable");
        }
        public int Status { get; set; }
        // implement ICompressible
        public void Compress()
        {
            Console.WriteLine("Implementing Compress");
        }
        public void Decompress()
        {
            Console.WriteLine("Implementing Decompress");
        }
        // implement ILoggedCompressible
        public void LogSavedBytes()
        {
            Console.WriteLine("Implementing LogSavedBytes");
        }
        // implement IStorableCompressible
        public void LogOriginalSize()
        {
            Console.WriteLine("Implementing LogOriginalSize");
        }
        // implement IEncryptable
        public void Encrypt()
        {
            Console.WriteLine("Implementing Encrypt");
        }
        public void Decrypt()
        {
            Console.WriteLine("Implementing Decrypt");
        }
    }
    class LittleDocument : Document, IEncryptable
    {
        public LittleDocument(string s)
        {
            Console.WriteLine("Creating document with: {0}", s);
        }
        void IEncryptable.Encrypt()
        {
            Console.WriteLine("Implementing Encrypt");
        }
        void IEncryptable.Decrypt()
        {
            Console.WriteLine("Implementing Decrypt");
        }
    }
    public class Tester
    {
        static void Main()
        {
            Document[] folder = new Document[5];
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    //polimorfismo
                    folder[i] = new BigDocument("Big Document # " + i);
                }
                else
                {
                    //polimorfismo
                    folder[i] = new LittleDocument("Little Document # " + i);
                }
            }

            //itera sui documenti  (posso farlo poichè sono figli di Document,
            //polimorfismo: oggetti di tipi diversi possono essere trattati come oggetti di un tipo comune.)
            foreach (Document doc in folder)
            {
                // cast con as a interfaccia IStorable
                // (il cast avviene solo se la classe implementa l'interfaccia a cui stai cercando di fare il cast.)
                IStorable isStorableDoc = doc as IStorable;
                if (isStorableDoc != null)
                {
                    isStorableDoc.Read();
                }
                else
                    Console.WriteLine("IStorable not supported");
                //provo per le altre interfacce
                ICompressible icDoc = doc as ICompressible;
                if (icDoc != null)
                {
                    icDoc.Compress();
                }
                else
                    Console.WriteLine("Compressible not supported");
                ILoggedCompressible ilcDoc = doc as ILoggedCompressible;
                if (ilcDoc != null)
                {
                
                ilcDoc.LogSavedBytes();
                ilcDoc.Compress();
                    // ilcDoc.Read( );
                 }
                else
                    Console.WriteLine("LoggedCompressible not supported");
                IStorableCompressible isc = doc as IStorableCompressible;
                if (isc != null)
                {
                    isc.LogOriginalSize(); // IStorableCompressible
                    isc.LogSavedBytes(); // ILoggedCompressible
                    isc.Compress(); // ICompressible
                    isc.Read(); // IStorable
                }
                else
                {
                    Console.WriteLine("StorableCompressible not supported");
                }
                IEncryptable ie = doc as IEncryptable;
                if (ie != null)
                {
                    ie.Encrypt();
                }
                else
                    Console.WriteLine("Encryptable not supported");
            }   // end for
        }       // end main
    }           // end class
}               // end namespace



/*
 IStorable isStorableDoc = doc as IStorable;

 L'operatore as tenta di eseguire un cast sicuro da un tipo a un altro. A differenza di un cast tradizionale, 
 che solleverebbe un'eccezione se il cast non è valido, as restituisce null se l'oggetto non è compatibile con 
 il tipo di destinazione.
Se doc non implementa IStorable, allora isStorableDoc sarà null.

Se doc è un oggetto di tipo BigDocument, che implementa IStorable:

Il cast avrà successo e isStorableDoc conterrà il riferimento all'oggetto castato. 
Potrai quindi invocare i metodi definiti in IStorable, come Read().

Se doc è un oggetto di tipo LittleDocument, che non implementa IStorable:

Il cast restituirà null, perché LittleDocument non implementa IStorable. 
In questo caso, non sarà possibile chiamare metodi di IStorable su doc (come Read()), 
e nel blocco else sarà stampato il messaggio "IStorable not supported".

IMPO -> Quindi, Dopo il casting, la variabile isStorableDoc (di tipo IStorable) contiene un riferimento 
all'oggetto doc se doc implementa l'interfaccia IStorable. 
Se doc non implementa l'interfaccia IStorable, isStorableDoc conterrà null.


Es:
public interface IStorable
{
    void Read();
    void Write(object obj);
    int Status { get; set; }
}

public class Document : IStorable
{
    public void Read() { Console.WriteLine("Reading document"); }
    public void Write(object obj) { Console.WriteLine("Writing document"); }
    public int Status { get; set; }
}

Document doc = new Document();
IStorable storableDoc = doc as IStorable;  // Funziona perché Document implementa IStorable

In questo caso, l'oggetto doc (di tipo Document) può essere trattato come un IStorable, 
perché la classe Document implementa l'interfaccia IStorable.

*/