
namespace _01_Destructors
{
    public class DestructorDemo
    {
        public DestructorDemo() 
        {
            Console.WriteLine("Constructor object created");
        }

        ~DestructorDemo() 
        {
            string type = GetType().Name;   //prende nome classe
            Console.WriteLine($"Object {type} is destryoed");
        }
    }
}



