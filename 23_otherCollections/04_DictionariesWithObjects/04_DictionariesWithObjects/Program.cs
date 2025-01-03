namespace Dictionaries
{

    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // key - value
            // Declaring and initializing a Dictionary
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            employees.Add(1, new Employee("John Does", 35, 100000));
            employees.Add(2, new Employee("John Doesnt", 25, 200000));
            employees.Add(3, new Employee("John Wasnt", 45, 80000));
            employees.Add(4, new Employee("John Will", 15, 50000));

            foreach (var item in employees)
            {
                Console.WriteLine($"ID: {item.Key} named: {item.Value.Name} " +
                    $"earns {item.Value.Salary}" +
                    $" and is {item.Value.Age} years old!");
            }

            Console.ReadKey();
        }
    }
}
