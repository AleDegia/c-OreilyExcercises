using System;
namespace ConstructorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CopyConstructor obj1 = new CopyConstructor(10);
            obj1.Display();
            CopyConstructor obj2 = new CopyConstructor(obj1);
            obj2.Display();
            Console.ReadKey();
        }
    }

    public class CopyConstructor
    {
        int x;

        //Parameterized Constructor
        public CopyConstructor(int i)
        {
            x = i;
        }

        //Copy Constructor
        public CopyConstructor(CopyConstructor obj)
        {
            x = obj.x;
        }

        public void Display()
        {
            Console.WriteLine($"Value of X = {x}");
        }
    }
}



/*
 * CopyConstructor obj1 = new CopyConstructor(10);
 * Se volessi passare 50 parametri sarebbe un problema farlo + volte, percio il reference:
 * Passando obj1 come parametro al costruttore di copia, l'oggetto obj1 viene utilizzato 
 * per inizializzare il nuovo oggetto (obj2) copiandone i valori.
 * obj.x equivale a obj1.x, che è 10.
 * obj1 e obj2 staranno in 2 diverse celle di memoria ma avranno gli stessi valori le var
 * 
 * obj è un riferimento all'oggetto obj1, ovvero obj punta alla stessa istanza di obj1 in memoria.
Tuttavia, all'interno del costruttore, si accede al valore del campo x di obj1 tramite obj.x. 
Questo valore viene copiato nel campo x del nuovo oggetto (obj2).

 * */