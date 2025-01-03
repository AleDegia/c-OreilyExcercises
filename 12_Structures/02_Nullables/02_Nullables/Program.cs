class Program
{
    static void Main(string[] args)
    {
        int? age = null;

        if(age.HasValue)
        {
            Console.WriteLine("Age is: " + age.Value);
        }
        else
        {
            Console.WriteLine("Age is not specified: " + age);
        }
    }
}

/*
 Value è accessibile solo quando HasValue è true, cioè quando la variabile ha un valore effettivo e non è null.
 Se è false e ci accedo, genera un'eccezione di tipo InvalidOperationException
*/