using System;
namespace AbstractClassMethods
{
    class Program
    {
        static void Main()
        {
            ImplementationClass1 obj1 = new ImplementationClass1();
            //Using obj1 we can only call Add method
            obj1.Add(10, 20);
            //We cannot call Sub method
            //obj1.Sub(100, 20);

            ImplementationClass2 obj2 = new ImplementationClass2();
            //Using obj2 we can call both Add and Sub method
            obj2.Add(10, 20);
            obj2.Sub(100, 20);

            ITestInterface1 obj = new ImplementationClass1();   //polimorfismo
            obj.Add(10, 20);    
          //obj.Wewe(5);    //errore -> ITestInterface1 does not contain a definition for Wewe 

            Console.ReadKey();
        }
    }

    interface ITestInterface1
    {
        void Add(int num1, int num2);
    }
    interface ITestInterface2 : ITestInterface1
    {
        void Sub(int num1, int num2);
    }

    public class ImplementationClass1 : ITestInterface1
    {
        //Implement only the Add method
        public void Add(int num1, int num2)     //Devo specificare public 
        {
            Console.WriteLine($"Sum of {num1} and {num2} is {num1 + num2}");
        }
        public void Wewe(int num1)
        {
            Console.WriteLine("wewe" + num1);
        }
    }

    public class ImplementationClass2 : ITestInterface2
    {
        //Implement Both Add and Sub method
        public void Add(int num1, int num2)
        {
            Console.WriteLine($"Sum of {num1} and {num2} is {num1 + num2}");
        }

        public void Sub(int num1, int num2)
        {
            Console.WriteLine($"Divison of {num1} and {num2} is {num1 - num2}");
        }
    }
}

/*
Una classe può implementare + interfacce, mentre puo ereditare solo una classe padre.

void add(int num1, int num2)	->  di default è public abstract, viene sottointeso

- il deault scope dei membri in un interfaccia è public. Nelle classi è private.
- di default ogni membro di un'interfaccia è abstract.
- le variabili non possono essere dichiarate in un interfaccia, e nemmeno i costruttori
- la classe che implementa un interfaccia deve implementare i suoi metodi.
(Per farlo non serve usare l'override)
- un interfaccia puo ereditare da un interfaccia

L'interfaccia serve principalmente per fare multiple inheritance, che non si puo fare con le classi

*/