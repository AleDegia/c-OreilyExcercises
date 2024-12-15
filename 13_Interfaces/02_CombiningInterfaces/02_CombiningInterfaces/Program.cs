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
    public class Document : IStorableCompressible, IEncryptable
    {
        // hold the data for IStorable's Status property
        private int status = 0;
        // the document constructor
        public Document(string s)
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
    public class Tester
    {
        static void Main()
        {
            // create a document object
            Document doc = new Document("Test Document");
            doc.Read();     //Implementing the Read Method for IStorable
            doc.Compress(); //Implementing Compress
            doc.LogSavedBytes();    //Di ILogCompressible..
            doc.Compress();
            doc.LogOriginalSize();
            doc.LogSavedBytes();
            doc.Compress();
            doc.Read();
            doc.Encrypt();
        }
    }
}

/*
 la classe dovra implementare i metodi di tutte le interfacce..
*/