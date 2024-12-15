
namespace UsingParams
{
    public class Tester
    {
        static void Main()
        {
            Tester t = new Tester();
            t.DisplayVals(5, 6, 7, 8);
            int[] explicitArray = new int[5] { 1, 2, 3, 4, 5 };
            t.DisplayVals(explicitArray);
        }

        //con params raggruppa in un array di interi i parametri passati singolarmente
        public void DisplayVals(params int[] intVals)
        {
            foreach (int i in intVals)
            {
                Console.WriteLine("DisplayVals {0}", i);
            }
        }
    }
}
