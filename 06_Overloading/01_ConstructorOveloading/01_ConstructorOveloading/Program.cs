using System;

namespace OverloadedConstructor
{
    public class Time
    {
        // Variabili membro private
        private int Year;
        private int Month;
        private int Date;
        private int Hour;
        private int Minute;
        private int Second;

        // Metodo per visualizzare l'orario
        public void DisplayCurrentTime()
        {
            Console.WriteLine("{0}/{1}/{2} {3}:{4}:{5}",
                Month, Date, Year, Hour, Minute, Second);
        }

        // Costruttore che accetta un oggetto DateTime
        public Time(DateTime dt)
        {
            Year = dt.Year;
            Month = dt.Month;
            Date = dt.Day;
            Hour = dt.Hour;
            Minute = dt.Minute;
            Second = dt.Second;
        }

        // Overloaded Constructor
        public Time(int year, int month, int date, int hour, int minute, int second)
        {
            Year = year;
            Month = month;
            Date = date;
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }

    public class Tester
    {
        static void Main()
        {
            // Creiamo un oggetto Time utilizzando il costruttore con DateTime
            DateTime currentTime = DateTime.Now;
            Time t1 = new Time(currentTime);
            t1.DisplayCurrentTime();

            // Creiamo un oggetto Time utilizzando il costruttore con parametri
            Time t2 = new Time(2007, 11, 18, 11, 03, 30);
            t2.DisplayCurrentTime();
        }
    }
}
