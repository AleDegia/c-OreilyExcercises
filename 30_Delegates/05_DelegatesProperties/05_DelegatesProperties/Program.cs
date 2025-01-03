using System;
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

            MethodInfo Method = del1.Method;    //info del metodo a cui il delegate è associato.
            object Target = del1.Target;    //l'oggetto che contiene il metodo che vado a dare come parametro al delegate
            Delegate[] InvocationList = del1.GetInvocationList();

            Console.WriteLine($"Method Property: {Method}");
            Console.WriteLine($"Target Property: {Target}");

            foreach (var item in InvocationList)
            {
                Console.WriteLine($"InvocationList: {item}");
            }

            Console.ReadKey();
        }
    }

    public class SomeClass
    {
        public void DoSomework(string message)
        {
            Console.WriteLine("DoSomework Executed");
            Console.WriteLine($"Hello: {message}, Good Morning");
        }
    }
}


/*
Quando si scrive del1.Method in C#, si sta accedendo alla proprietà Method del delegate del1. 
Questo ritorna un oggetto di tipo MethodInfo, che rappresenta il metodo a cui il delegate è associato.

Nel tuo caso, del1 è un delegate di tipo DoSomeMethodHandler, che è associato al metodo DoSomework della classe SomeClass.
Quindi, quando si accede a del1.Method, si ottiene un oggetto MethodInfo che contiene informazioni dettagliate sul metodo DoSomework 
a cui il delegate fa riferimento (nome, tipo di ritorno, parametri, ecc)

Quando scrivi del1.Target in C#, stai accedendo alla proprietà Target di un delegate. 
Questa proprietà restituisce l'oggetto a cui è associato il delegate. 
In altre parole, l'oggetto su cui il delegate invoca il metodo.
Il "target object" è l'oggetto che contiene il metodo che vado a dare come parametro al delegate

La funzione GetInvocationList in C# è un metodo che restituisce un array di delegati associati a un delegate. 
Questa funzionalità è utile quando un delegate è multicast, ovvero quando è associato a più metodi 
*/