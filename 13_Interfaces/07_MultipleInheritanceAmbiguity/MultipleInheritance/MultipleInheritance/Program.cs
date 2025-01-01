public interface Interface1
{
    void Test();
}
public interface Interface2
{
    void Test();
}


public class MultipleInheritanceTest : Interface1, Interface2
{
    public void Test()
    {
        Console.WriteLine("implemented");
    }
}


namespace MultipleInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            MultipleInheritanceTest obj = new MultipleInheritanceTest();
            obj.Test();     //"implemented"
           
        }
    }
}


/*
 * quale metodo Test() verra chiamato tra interfaccia1 e interfaccia2?
   vengono implementati entrambi.

per implementarli separatamente dovrei fare:

public class MultipleInheritanceTest : Interface1, Interface2
{
    void Interface1.Test()
    {
        Console.WriteLine("Interface1 Test implementation");
    }

    void Interface2.Test()
    {
        Console.WriteLine("Interface2 Test implementation");
    }
}
 * */