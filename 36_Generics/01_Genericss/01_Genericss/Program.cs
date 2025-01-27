//Una classe non generica puo comunque avere proprietà o metodi generici
internal class Box<T>
{
    private T content;  //sarà del tipo della classe

    public Box(T initialValue)
    {
        content = initialValue;
    }

    public void UpdateContent(T newContent)
    {
        content = newContent;
        Console.WriteLine("Updated content to {content}"); 
    }
}


class Program
{
    static void Main(string[] args)
    {
        Box<string> box = new Box<string>("Hello World");
        box.UpdateContent("wewe");
    }
}
