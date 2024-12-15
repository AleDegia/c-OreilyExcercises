using System;

namespace ReturningValuesInParams
{
    public class Time
    {
        // Private member variables to store time details
        private int Year;
        private int Month;
        private int Date;
        private int Hour;
        private int Minute;
        private int Second;

        // Public method to display the current time in a formatted way
        public void DisplayCurrentTime()
        {
            Console.WriteLine("{0}/{1}/{2} {3}:{4}:{5}",
                Month, Date, Year, Hour, Minute, Second);
        }

        // Public method to get the hour of the time
        public int GetHour()
        {
            return Hour;
        }

        // ref parameters are references to the actual original value: 
        // per via di ref i parametri non sono copie, percio cambando i valori dei parametri cambierà il valore
        //delle variabili originali (globali)
        public void GetTime(ref int h, ref int m, ref int s)
        {
            h = Hour;
            m = Minute;
            s = Second;
        }

        // Constructor to initialize the time based on a DateTime object
        public Time(DateTime dt)
        {
            Year = dt.Year;
            Month = dt.Month;
            Date = dt.Day;
            Hour = dt.Hour;
            Minute = dt.Minute;
            Second = dt.Second;
        }
    }

    public class Tester
    {
        static void Main()
        {
            // Get the current time
            DateTime currentTime = DateTime.Now;

            // Create a Time object initialized with the current time
            Time t = new Time(currentTime);

            // Display the current time
            t.DisplayCurrentTime();

            // Declare variables to hold the hour, minute, and second
            //(devo passarle inizializzate al metodo, senno da errore -> out keyword)
            int theHour = 0;
            int theMinute = 0;
            int theSecond = 0;

            // Get the time using the 'ref' parameters
            t.GetTime(ref theHour, ref theMinute, ref theSecond);

            // Display the time using the retrieved values
            Console.WriteLine("Current time: {0}:{1}:{2}", theHour, theMinute, theSecond);
        }
    }
}


/*
 *  Second, modify the call to GetTime() to pass the arguments as references as well:
 t.GetTime(ref theHour, ref theMinute, ref theSecond);
 If you leave out the second step of marking the arguments with the keyword ref, the
 compiler will complain that the argument can’t be converted from an int to a ref
 int.

theHour, theMinute e theSecond devo passarle inizializzate al metodo GetTime, senno da errore.
Se invece il metodo GetTime le prendesse come out parameters, non ci sarebbe problema, ma dovrò comunque
assegnare un valore a queste variabili prima che il metodo ritorni un valore.

ref e out si mettono percio in + prima di tipoDellaVariabile e variabile 
*/
