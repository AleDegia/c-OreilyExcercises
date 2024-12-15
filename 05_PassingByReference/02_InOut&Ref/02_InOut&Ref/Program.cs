namespace InOutRef
{
    public class Time
    {
        // Variabili membri private
        private int Year;
        private int Month;
        private int Date;
        private int Hour;
        private int Minute;
        private int Second;

        // Metodo per visualizzare l'orario corrente
        public void DisplayCurrentTime()
        {
            System.Console.WriteLine("{0}/{1}/{2} {3}:{4}:{5}",
                Month, Date, Year, Hour, Minute, Second);
        }

        // Metodo per ottenere l'ora
        public int GetHour()
        {
            return Hour;
        }

        // Metodo per impostare l'orario (min è out perchè nel main viene passato non inizializzato)
        public void SetTime(int hr, out int min, ref int sec)   
        {
            // Se il secondo passato è maggiore o uguale a 30
            // incrementiamo il minuto e impostiamo il secondo a 0
            // altrimenti lasciamo tutto invariato
            if (sec >= 30)
            {
                Minute++;
                Second = 0;
            }

            Hour = hr; // Impostiamo l'ora al valore passato
            // Restituiamo il minuto e il secondo modificati
            min = Minute;
            sec = Second;
        }

        // Costruttore che inizializza l'orario a partire da un oggetto DateTime
        public Time(System.DateTime dt)
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
            // Otteniamo l'orario corrente
            System.DateTime currentTime = System.DateTime.Now;

            // Creiamo un oggetto Time con l'orario corrente
            Time t = new Time(currentTime);

            // Visualizziamo l'orario corrente
            t.DisplayCurrentTime();

            // Impostiamo l'orario a 3 ore, con 20 secondi
            int theHour = 3;
            int theMinute;
            int theSecond = 20;

            //non entrera nell'if
            t.SetTime(theHour, out theMinute, ref theSecond);

            // Mostriamo l'ora aggiornata
            System.Console.WriteLine("The minute is now: {0} and {1} seconds", theMinute, theSecond);

            // Impostiamo i secondi a 40 e chiamiamo di nuovo SetTime
            theSecond = 40;
            t.SetTime(theHour, out theMinute, ref theSecond);

            // Mostriamo l'ora aggiornata
            System.Console.WriteLine("The minute is now: {0} and {1} seconds", theMinute, theSecond);
        }
    }
}
