using System;
namespace Conversions
{
    public class Fraction
    {
        private int numerator;
        private int denominator;
        public Fraction(int numerator, int denominator)
        {
            Console.WriteLine("In Fraction Constructor(int, int)");
            this.numerator = numerator;
            this.denominator = denominator;
        }

        //altro costruttore per creare frazione partendo da un numero intero
        public Fraction(int wholeNumber)
        {
            Console.WriteLine("In Fraction Constructor(int)");
            numerator = wholeNumber;
            denominator = 1;
        }
        //operatore conversione implicita
        public static implicit operator Fraction(int theInt)
        {
            Console.WriteLine("In implicit conversion to Fraction");
            return new Fraction(theInt);    //Chiamo secondo costruttore
        }
        public static explicit operator int(Fraction theFraction)
        {
            Console.WriteLine("In explicit conversion to int");
            return theFraction.numerator / theFraction.denominator;
        }
        public static bool operator ==(Fraction lhs, Fraction rhs)
        {
            Console.WriteLine("In operator ==");
            if (lhs.denominator == rhs.denominator &&
            lhs.numerator == rhs.numerator)
            {
                return true;
            }
            // code here to handle unlike fractions
            return false;
        }
        public static bool operator !=(Fraction lhs, Fraction rhs)
        {
            Console.WriteLine("In operator !=");
            return !(lhs == rhs);
        }
        public override bool Equals(object o)
        {
            Console.WriteLine("In method Equals");
            if (!(o is Fraction))
            {
                return false;
            }
            return this == (Fraction)o;
        }

        //operatore + personalizzato (funge se messo tra 2 ogg Fraction)
        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            Console.WriteLine("In operator+");
            if (lhs.denominator == rhs.denominator) //se i denominatori sono uguali
            {
                //chiamo costruttore Fraction(int numerator, int denomitor)
                return new Fraction(lhs.numerator + rhs.numerator,
                lhs.denominator);
            }
            // simplistic solution for unlike fractions
            // 1/2 + 3/4 == (1*4) + (3*2) / (2*4) == 10/8
            int firstProduct = lhs.numerator * rhs.denominator;
            int secondProduct = rhs.numerator * lhs.denominator;
            return new Fraction(
            firstProduct + secondProduct,
            lhs.denominator * rhs.denominator
            );
        }
        public override string ToString()
        {
            String s = numerator.ToString() + "/" +
            denominator.ToString();
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(3, 4);               // In Fraction Constructor(int, int)
            Console.WriteLine("f1: {0}", f1.ToString());    // f1: 3/4
            Fraction f2 = new Fraction(2, 4);               // In Fraction Constructor(int, int)
            Console.WriteLine("f2: {0}", f2.ToString());    // f2: 2/4
            Fraction f3 = f1 + f2;   // + tra 2 oggetti ->  // In operator +  //In Fraction Constructor(int, int)
            Console.WriteLine("f1 + f2 = f3: {0}", f3.ToString());  //f1 + f2 = f3: 5/4
            //ogg + int -> c# chiama operatore di conversione imp per soddisfare il + che vuole 2 parametri di tipo Fraction
            Fraction f4 = f3 + 5;                           //In implicit conversion to Fraction
                                                            //In Fraction Constructor(int)
                                                            //In operator+
                                                            //In Fraction Constructor(int, int)
            Console.WriteLine("f3 + 5 = f4: {0}", f4.ToString());
            Fraction f5 = new Fraction(2, 4);
            if (f5 == f2)                                   // In operator ==
            {
                Console.WriteLine("F5: {0} == F2: {1}", f5.ToString(), f2.ToString());
                //F5: 2/4 == F2: 2/4
            }
        }
    }
}


/*
In C#, le parole chiave implicit e operator sono utilizzate in combinazione per definire un operatore di 
conversione che consente di convertire un tipo in un altro senza richiedere un cast esplicito da parte del programmatore.

operator indica che stai dichiarando un operatore di conversione. 
Qui, stai definendo un operatore che permette di convertire un intero (int) in una frazione (Fraction),
Questo operatore è statico perché deve essere associato alla classe Fraction e non a una singola istanza di essa.

Quando scrivi f3 + 5, stai cercando di sommare un oggetto di tipo Fraction (associato a f3) e un valore di tipo 
int (che è 5), ma l'operatore + è definito nella tua classe Fraction solo per sommare due oggetti di tipo Fraction. 
Per fare questa somma, C# deve prima "convertire" l'intero (int) in una frazione (Fraction), 
in modo che entrambe le variabili coinvolte siano dello stesso tipo.
Poiché l'operatore + non è definito per sommare direttamente una Fraction e un int, C# deve trovare un modo per 
convertire l'intero 5 in una frazione, in modo che entrambe le operazioni possano essere eseguite con oggetti di tipo 
Fraction.

Attivazione della conversione implicita: 
A questo punto, C# cerca se esiste un operatore di conversione che può convertire l'int in una Fraction.
Nel tuo caso, c'è un operatore di conversione implicita che lo fa: operator Fraction(int theInt)

*/