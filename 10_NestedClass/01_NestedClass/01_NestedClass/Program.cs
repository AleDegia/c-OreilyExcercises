using System;
namespace Nested_Class
{
    public class Fraction
    {
        private int numerator;
        private int denominator;
        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public override string ToString()
        {
            return String.Format("{0}/{1}",
                numerator, denominator);
        }
        
        //serve a mostrare numeratore e denominatore
        internal class FractionArtist
        {
            public void Draw(Fraction f)    //prende oggetto Fraction come parametro
            {
                Console.WriteLine("Drawing the numerator: {0}",
                    f.numerator);
                Console.WriteLine("Drawing the denominator: {0}",
                    f.denominator);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(3, 4);
            Console.WriteLine("f1: {0}", f1.ToString());
            //per fare ogg della classe interna si fa  ClasseOuter.ClasseInner obj = new ClasseOuter.ClasseInner();
            Fraction.FractionArtist fa = new Fraction.FractionArtist();
            fa.Draw(f1);
        }
    }
}

/*

output:
 
f1: 3/4
Drawing the numerator: 3
Drawing the denominator: 4


IMPO ->  Draw() has access to the private data members f.numerator and f.denominator, to which it
         wouldn’t have had access if it weren’t a nested class

*/

