
namespace _01_Generics
{
    public interface IImportance<T>
    {
        T MostImportant(T a, T b);
    }
}
