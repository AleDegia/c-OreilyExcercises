using System;
namespace ConstructorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedConstructor obj1 = new ParameterizedConstructor(10);
            obj1.Display();
            ParameterizedConstructor obj2 = new ParameterizedConstructor(20);
            obj2.Display();
            Console.ReadKey();
        }
    }

    public class ParameterizedConstructor
    {
        int x;
        public ParameterizedConstructor(int i)
        {
            Console.WriteLine($"Parameterized Constructor is Called : {i}");    //Prima 10, poi 20
        }
        public void Display()
        {
            Console.WriteLine($"Value of X = {x}");     //0  
        }
    }
}


/*
 * In C#, quando crei un oggetto, i campi della classe sono automaticamente inizializzati con valori di default, 
 * se non vengono esplicitamente assegnati nel costruttore o altrove.
 * Il costruttore è chiamato con il valore 10, ma non assegna nulla al campo x, quindi x rimane il valore predefinito,
 * ovvero 0.
 * 
 * La memoria per le variabili è allocata nell'heap alla creazione dell oggetto, poiche variabili d istanza, per i 
 * reference invece viene allocata nello stack.
 */