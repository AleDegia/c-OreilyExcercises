using System;
namespace DelegatesDemo
{
    public delegate void WorkPerformedHandler(int hours, WorkType workType);

    class Program
    {
        static void Main(string[] args)
        {
            //Creo delegate che prende come parametro un metodo con numero e tipo di param uguali a quelli nella definizione del delegate
            WorkPerformedHandler del1 =
                        new WorkPerformedHandler(Manager_WorkPerformed);
            del1(10, WorkType.Golf);    //chiamo il delegate come se fosse un metodo
            //del1.Invoke(50, WorkType.GotoMeetings);

            Console.ReadKey();
        }

        public static void Manager_WorkPerformed(int workHours, WorkType wType)
        {
            Console.WriteLine("Work Performed by Event Handler");
            Console.WriteLine($"Work Hours: {workHours}, Work Type: {wType}");
        }
    }

    public enum WorkType
    {
        Golf,
        GotoMeetings,
        GenerateReports
    }
}


/*
Qui viene dichiarato un delegato chiamato WorkPerformedHandler. Questo delegato può fare riferimento a metodi che prendono due parametri:

int hours 
WorkType workType

Il tipo di ritorno del delegato è void, il che significa che i metodi a cui questo delegato fa riferimento non restituiscono alcun valore.


WorkPerformedHandler del1 = new WorkPerformedHandler(Manager_WorkPerformed);
del1(10, WorkType.Golf);

Qui viene creato un oggetto delegato del1, che è associato al metodo Manager_WorkPerformed.

Manager_WorkPerformed è il metodo che verrà invocato quando si chiamerà il delegato del1.

Viene quindi invocato il delegato del1, passando 10 come valore per le ore di lavoro e WorkType.Golf come tipo di lavoro. 
Questo farà sì che venga eseguito il metodo Manager_WorkPerformed, passando questi valori come argomenti.

Un delegato è un tipo proprio, come una classe o una struttura. Definirlo al di fuori della classe permette di riutilizzarlo in altre parti del programma, non solo all'interno di Program. In altre parole, se volessi usare il delegato in altre classi o metodi, sarebbe più facile se fosse definito a livello di spazio dei nomi (namespace).
In questo modo, ogni classe nel namespace DelegatesDemo potrebbe utilizzare WorkPerformedHandler, senza bisogno di ridefinirlo in ogni classe.
*/