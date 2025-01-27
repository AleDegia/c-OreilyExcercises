internal interface IEntity
{
    int Id { get; set; }
}

internal class Repository<T> where T : IEntity
{
    private List<T> _values = new List<T>();

    public void Add(T entity)
    { 
        _values.Add(entity); 
    }
}

class Product : IEntity
{
    public int Id { get; set; }
}


class Program
{
    static void Main(string[] args)
    {
        
        Repository<Product> repository = new Repository<Product>();
        var product = new Product();
        repository.Add(product);
    }
}