using System;

namespace UsingVirtualMethods
{
    // Classe base
    public class Control
    {
        // Membri protetti visibili alle classi derivate
        protected int Top { get; set; }
        protected int Left { get; set; }

        // Costruttore per inizializzare la posizione
        public Control(int top, int left)
        {
            this.Top = top;
            this.Left = left;
        }

        // Metodo virtuale che può essere sovrascritto
        public virtual void DrawWindow()
        {
            Console.WriteLine($"Control: Drawing Control at {Top}, {Left}");
        }
    }

    // Classe derivata ListBox
    public class ListBox : Control
    {
        private string listBoxContents; // Nuovo membro della classe derivata

        // Costruttore che accetta parametri aggiuntivi e chiama il costruttore della base
        public ListBox(int top, int left, string contents) : base(top, left)
        {
            listBoxContents = contents;
        }

        // Sovrascrive il metodo DrawWindow della classe base
        public override void DrawWindow()
        {
            base.DrawWindow(); // Chiama il metodo della classe base
            Console.WriteLine($"Writing string to the listbox: {listBoxContents}");
        }
    }

    // Classe derivata Button
    public class Button : Control
    {
        // Costruttore che chiama il costruttore della classe base
        public Button(int top, int left) : base(top, left)
        {
        }

        // Sovrascrive il metodo DrawWindow della classe base
        public override void DrawWindow()
        {
            Console.WriteLine($"Drawing a button at {Top}, {Left}");
        }
    }

    // Classe principale del programma
    class Program
    {
        static void Main(string[] args)
        {
            // Creazione di oggetti singoli
            Control win = new Control(1, 2);
            ListBox lb = new ListBox(3, 4, "Stand alone list box");
            Button b = new Button(5, 6);

            win.DrawWindow();   //Control: Drawing Control at 1, 2
            lb.DrawWindow();    //Control: Drawing Control at 3, 4   Writing string to the listbox: Stand alone list box
            b.DrawWindow();     //Drawing a button at 5, 6

            // Array di oggetti Control (polimorfismo)
            Control[] winArray = new Control[3];
            winArray[0] = new Control(1, 2);
            winArray[1] = new ListBox(3, 4, "List box in array");
            winArray[2] = new Button(5, 6);

            // Iterazione e chiamata del metodo DrawWindow
            for (int i = 0; i < 3; i++)
            {
                winArray[i].DrawWindow();
            }

            /*
             Control: Drawing Control at 1, 2
             Control: Drawing Control at 3, 4
             Writing string to the listbox: List box in array
             Drawing a button at 5, 6
            */
        }
    }
}



/*
 Il costruttore della classe derivata ListBox chiama il costruttore della classe base Control per assicurarsi che le
proprietà definite nella classe base vengano inizializzate correttamente. Questo è fondamentale perché la classe derivata
eredita sia i membri (proprietà, campi, metodi) della classe base, sia il loro comportamento

Quando un oggetto della classe derivata ListBox viene creato, ecco cosa succede:

Chiamata al costruttore della classe derivata: Quando si crea un nuovo oggetto ListBox, ad esempio:

ListBox lb = new ListBox(3, 4, "Some contents");
il costruttore di ListBox viene invocato.

Invocazione del costruttore della classe base: 
Prima che il corpo del costruttore di ListBox venga eseguito, viene chiamato il costruttore della classe base (Control), 
grazie alla linea : base(top, left). Questo inizializza i membri ereditati, come Top e Left.

Esecuzione del corpo del costruttore della classe derivata: Dopo l'inizializzazione della classe base, 
viene eseguito il corpo del costruttore della classe derivata, che inizializza i membri specifici della classe derivata,
come listBoxContents.

Una classe derivata non dovrebbe essere responsabile dell'inizializzazione o della gestione dei dettagli definiti dalla classe base. 
Ogni classe ha un ambito di responsabilità.

 classes can’t inherit constructors, a derived class must implement its own
 constructor and can only make use of the constructor of its base class by calling it
 explicitly.

Quando un figlio eredita da una classe padre un campo (o un metodo), 
quel campo viene ereditato dalla classe figlia. Questo significa che il campo è accessibile dalle istanze della classe 
figlia, ma formalmente appartiene ancora alla classe padre se non viene ridefinito nella figlia.
(papà ha la macchian, te come figlio puoi usarla ma la macchina appartiene sempre al padre)

La classe base consente l'uso del polimorfismo. Questo significa che possiamo trattare oggetti derivati (ListBox, Button) come oggetti della classe base (Control). Ad esempio:

Control[] controls = new Control[3];
controls[0] = new Control(1, 2);
controls[1] = new ListBox(3, 4, "List contents");
controls[2] = new Button(5, 6);

foreach (var control in controls)
{
    control.DrawWindow(); // Chiama la versione appropriata del metodo
}

*/