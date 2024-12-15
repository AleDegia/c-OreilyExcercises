using System;

namespace TestingGenericsApp
{
    public class TestingGenerics
    {
        public static void Main(string[] args)
        {
            var intArray = CreateArray(5, 6);
            Console.WriteLine(string.Join(", ", intArray));

            var stringArray = CreateArray("Hello", "World");
            Console.WriteLine(string.Join(", ", stringArray));
        }

        private static T[] CreateArray<T>(T firstElement, T secondElement)
        {
            //ritorno array per metterlo nella intArray/stringArray
            return new T[] { firstElement, secondElement };
        }
    }
}

//non generic sarebbe:  public static int[] CreateArray(int firstElement, int secondElement){}