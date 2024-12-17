using overridingInterface;
using System;
namespace overridingInterface
{
    interface IStorable
    {
        void Read();
        void Write();
    }
    // Simplify Document to implement only IStorable
    public class Document : IStorable
    {
        // the document constructor
        public Document(string s)
        {
            Console.WriteLine(
            "Creating document with: {0}", s);
        }
        // implemento il metodo dell'interfaccia come virtual
        public virtual void Read()
        {
            Console.WriteLine(
            "Document Read Method for IStorable");
        }
        // NB: Not virtual!
        public void Write()
        {
            Console.WriteLine(
            "Document Write Method for IStorable");
        }
    }
    // Derive from Document (eredito anche interfaccia implementata dalla classe padre)
    public class Note : Document
    {
        public Note(string s) : base(s)
        {
            Console.WriteLine(
            "Creating note with: {0}", s);
        }
        
        // override the Read method
        public override void Read()
        {
            Console.WriteLine(
            "Overriding the Read method for Note!");
        }
        // implement my own Write method
        public new void Write()
        {
            Console.WriteLine(
            "Implementing the Write method for Note!");
        }
    }
    public class Tester
    {
        static void Main()
        {
            Document theNote = new Note("Test Note");
            IStorable isNote = theNote as IStorable;
            if (isNote != null) //se isNote implementa IStorable
            {
                isNote.Read();  //chiama Read overridden
                isNote.Write(); //chiama Write di Document
            }
            Console.WriteLine("\n");
            // direct call to the methods through base class reference
            theNote.Read();
            theNote.Write();
            Console.WriteLine("\n");
            // create a note object
            Note note2 = new Note("Second Test");
            IStorable isNote2 = note2 as IStorable;
            if (isNote2 != null)
            {
                isNote2.Read();
                isNote2.Write();    //Chiama sempre il Write di Document
            }
            
            Console.WriteLine("\n");
            // directly call the methods
            note2.Read();   //Overriding the Read method for Note!
            note2.Write();
        }
    }
}


/*
 When isNote.Write() is called, it uses the Write method defined in Document, as this is the version of the method 
known to the interface IStorable.
he new keyword allows you to provide a different implementation for Write when accessed through a Note reference, 
but this new version is not considered when the object is treated as an IStorable.

The interface only knows about the Write method provided by Document (the class that originally implemented the 
interface). It does not "see" the new method in Note, because Note.Write() is not an override; it is a new, 
unrelated method in the eyes of the interface.
Quando si crea un oggetto di una classe che implementa un'interfaccia, puoi utilizzare un riferimento dell'interfaccia 
per accedere ai metodi o alle proprietà definite nell'interfaccia.

il metodo viene trovato perché il riferimento isNote2 è di tipo IStorable, e IStorable definisce il metodo Write. 
Quindi il compilatore sa che qualsiasi oggetto che implementa IStorable avrà un metodo Write, 
poiché è obbligatorio per il contratto dell'interfaccia.

In isNote2.Read();

When the object (note2) is accessed through the IStorable reference, the interface resolves Write to the implementation
in Document, because:
IStorable was originally implemented by Document. (the parent class)
The Write method in Document is the one bound to IStorable.Write.

Anche se Note implementa IStorable, il comportamento di isNote2.Write() è determinato dalla definizione originale 
di IStorable in Document.


es:

public interface IStorable
{
    void Read();  // metodo obbligatorio per l'interfaccia
    void Write(); // metodo obbligatorio per l'interfaccia
}

public class Document : IStorable
{
    public void Write()
    {
        Console.WriteLine("Document Write Method for IStorable");
    }

    public void Read()
    {
        Console.WriteLine("Document Read Method for IStorable");
    }
}

public class Note : Document
{
    // Ridefinisco senza il new (sarebbe implicito)
    public void Write()
    {
        Console.WriteLine("Note Write Method");
    }
}


come puo Note non implementare Read se l'interfaccia vuole che lo implementi?

IMPO -> La classe Note non implementa Read(). Infatti, Note eredita Document, ma la classe base Document implementa già Read(). 
In questo caso, Note non è obbligata a ridefinire Read(), perché ereditando Document, ha già l'implementazione di Read().


*/