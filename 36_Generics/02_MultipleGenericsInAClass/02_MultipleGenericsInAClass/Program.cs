internal class Box<T, K>
{
    public T First { get; set; }
    public K Second { get; set; }

    public Box(T first, K second)
    {
        First = first;
        Second = second;
    }

    public void Display ()
    {
        Console.WriteLine($"First:{First} Second: {Second}");
    }
}


internal class Program
{
    static void Main(string[] args)
    {
        Box<int, string> box = new Box<int, string> (100, "ciao");
        box.Display();
    }
}