using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Hashtable studentsTable = new Hashtable();

        Student stud1 = new Student(1, "Maria", 98);
        Student stud2 = new Student(2, "Ale", 76);
        Student stud3 = new Student(3, "Luigi", 88);

        studentsTable.Add(stud1.Id, stud1);
        studentsTable.Add(stud2.Id, stud2);
        studentsTable.Add(stud3.Id, stud3);

        //devo castare da 'object' a 'Student'
        Student storedStudent1 = (Student)studentsTable[stud1.Id];

        Console.WriteLine("Student ID:{0}, Name:{1}, Gpa:{2}", storedStudent1.Id, storedStudent1.Name, storedStudent1.Age);

        foreach(DictionaryEntry entry in studentsTable)
        {
            Student temp = (Student)entry.Value;
            Console.WriteLine("Student ID:{0}", temp.Id);
            Console.WriteLine("Student Name:{0}", temp.Name);
            Console.WriteLine("Student Gpa:{0}", temp.Age);
        }

        //metodo migliore x iterare sui valori
        foreach (Student value in studentsTable.Values)
        {
            Console.WriteLine("Student ID:{0}", value.Id);
            Console.WriteLine("Student Name:{0}", value.Name);
            Console.WriteLine("Student Gpa:{0}", value.Age);
        }
    }
}


class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
}


/*
 * Hashtable è una collezione non generica, quindi memorizza i suoi valori come oggetti di tipo object
 * 
Quando accedi a un valore in una Hashtable tramite studentsTable[1], ottieni un valore di tipo object, 
che deve essere castato al tipo corretto, come Student in questo caso.
Se stai iterando sulla Hashtable con foreach, ogni elemento è un DictionaryEntry, che rappresenta una coppia chiave-valore.

La Hashtable in C# non garantisce un ordine specifico degli elementi. 
Questo significa che quando aggiungi elementi in una Hashtable, non c'è alcuna garanzia che vengano restituiti nell'ordine in cui sono stati inseriti.
La Hashtable utilizza un algoritmo di hashing interno che distribuisce le chiavi in base ai valori hash calcolati. 
Questo può portare a una distribuzione degli elementi che non segue l'ordine in cui sono stati aggiunti.
 */