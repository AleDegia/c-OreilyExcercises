class Program
{
    static void Main(string[] args)
    {
        Test obj = new Test();
        Console.WriteLine($"i = {obj.i}");
        Console.WriteLine($"b = {obj.b}");

        //value null will be printed
        if(obj.s == null)
        {
            Console.WriteLine("s = null");
        }
    }
}


class Test
{
    public int i;
    public bool b;
    public string s;
}


/*
 il costruttore di default sta inizializzando le variabili
 Vengono assegnati i valori di default solo se le variabili non ha++*/