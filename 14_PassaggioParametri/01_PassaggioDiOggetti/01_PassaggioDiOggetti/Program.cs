public class Location
{
    public int X { get; set; }
    public int Y { get; set; }
}

class Program
{
    public static void ModifyObject(Location loc)
    {
        // Modifica dello stato dell'oggetto tramite il riferimento
        loc.X = 50;
        loc.Y = 100;

        // Assegnazione di un nuovo oggetto al riferimento (non influisce all'esterno)
        loc = new Location { X = 0, Y = 0 };
        Console.WriteLine("Inside ModifyObject: loc = {0}, {1}", loc.X, loc.Y);
    }

    static void Main()
    {
        Location loc1 = new Location { X = 200, Y = 300 };

        Console.WriteLine("Before ModifyObject: loc1 = {0}, {1}", loc1.X, loc1.Y);

        ModifyObject(loc1);

        Console.WriteLine("After ModifyObject: loc1 = {0}, {1}", loc1.X, loc1.Y);
    }
}
/*
 Output:
Before ModifyObject: loc1 = 200, 300
Inside ModifyObject: loc = 0, 0         ->    stampo i valori di un nuovo ogg creato
After ModifyObject: loc1 = 50, 100      ->    stampo i valori cambiati all oggetto passato come parametro al metodo
*/