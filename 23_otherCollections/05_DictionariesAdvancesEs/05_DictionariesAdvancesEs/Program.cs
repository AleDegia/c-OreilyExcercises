using System; //using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Exercise
    {
        static void Main(string[] args)
        {
            // Creazione del dizionario con chiavi stringa e valori Student
            Dictionary<string, Student> dict = new Dictionary<string, Student>
            {
                {"John", new Student(1, "John", 85)},
                {"Alice", new Student(2, "Alice", 90)},
                {"Bob", new Student(3, "Bob", 78)}
            };

            // Creazione dell'istanza della classe Exercise e chiamata al metodo PrintStudents
            Exercise exc = new Exercise();
            exc.PrintStudents(dict);  // Passa il dizionario al metodo
        }

        // Metodo PrintStudents che accetta un dizionario come parametro
        public void PrintStudents(Dictionary<string, Student> dict)
        {
            // Ciclo per iterare sui valori del dizionario
            foreach (Student stu in dict.Values)  // 'dict.Values' contiene una raccolta di oggetti Student
            {
                // Stampa dei dettagli dello studente
                Console.WriteLine($"Name: {stu.Name}, Id: {stu.Id}, Grade: {stu.Grade}");
            }
        }
    }

    // Classe Student che contiene Id, Name e Grade
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }

        // Costruttore per inizializzare gli attributi
        public Student(int id, string name, int grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
    }
}
