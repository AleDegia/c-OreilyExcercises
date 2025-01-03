using System;
namespace DelegatesDemo
{
    public delegate void CallbackMethodHandler(string message);

    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            CallbackMethodHandler del1 = new CallbackMethodHandler(obj.CallbackMethod);
            //Here, I am calling the DoSomework function and I want the 
            //DoSomework function to call the delegate at some point of time
            //which will invoke the CallbackMethod method
            DoSomework(del1);

            Console.ReadKey();
        }

        public static void DoSomework(CallbackMethodHandler del)
        {
            Console.WriteLine("Processing some Task");
            del("Pranaya");
        }

        //non essendo static devo accederci creando oggetto della classe Program (obj)
        public void CallbackMethod(string message)
        {
            Console.WriteLine("CallbackMethod Executed");
            Console.WriteLine($"Hello: {message}, Good Morning");
        }
    }
}


/*
 Posso creare una funzione a cui passo un delegato come parametro, e quella funzione può chiamare il metodo associato al delegato. 
 Questo è un pattern comune in C# per passare comportamenti o azioni dinamiche a un altro metodo.
*/