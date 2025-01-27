internal class Logger
{
    public void Log<T>(T message)
    {
        Console.WriteLine(message.ToString());
    }
}


class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();
        logger.Log(10);
        logger.Log("Hello World");
        logger.Log(new { Name = "John", Age = 12 });
    }
}