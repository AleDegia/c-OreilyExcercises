using System.Reflection;

namespace DelegatesDemo
{
    public delegate void DoSomeMethodHandler(string message);

    class Program
    {
        static void Main(string[] args)
        {
            SomeClass obj = new SomeClass();
            DoSomeMethodHandler del1 = new DoSomeMethodHandler(obj.DoSomework);
            del1 += obj.DoSomework2;
            del1("Hi");

            MethodInfo Method = del1.Method;    //info del metodo a cui il delegate è associato.
            object Target = del1.Target;    //la classe che contiene il metodo che vado a dare come parametro al delegate
            Delegate[] InvocationList = del1.GetInvocationList();

            //Console.WriteLine($"Method Property: {Method}");
            //Console.WriteLine($"Target Property: {Target}");

            //foreach (var item in InvocationList)
            //{
            //    Console.WriteLine($"InvocationList: {item}");   //stampo il nome di ogni istanza del delegato
            //}

            Console.ReadKey();
        }
    }

    public class SomeClass
    {
        public  void DoSomework(string message)
        {
            Console.WriteLine("DoSomework Executed");
            Console.WriteLine($"Hello: {message}, Good Morning");
        }

        public void DoSomework2(string message)
        {
            Console.WriteLine("DoSomework2 Executed");
            Console.WriteLine($"Hello: {message}, Good Night");
        }
    }
}

/*
 * del1 += obj.Method2;
stai aggiungendo un altro metodo al delegato del1. 
In particolare, stai creando un delegato multicast, che è un tipo di delegato che può essere associato a più di un metodo.

l'operatore += applicato a un delegato viene utilizzato per aggiungere un metodo alla lista di metodi che il delegato invoca.

Ora, quando il delegato del1 viene invocato, entrambi i metodi associati al delegato 
verranno eseguiti uno dopo l'altro. (in ordine di come sono stati aggiunti)
*/