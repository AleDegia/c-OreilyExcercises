using System;

class Testing : IDisposable
{
    private bool is_disposed = false;

    // Metodo protetto per gestire la logica del Dispose
    protected virtual void Dispose(bool disposing)
    {
        if (!is_disposed) // Evita il doppio rilascio
        {
            if (disposing)
            {
                // Risorse gestite possono essere referenziate
                Console.WriteLine("Not in destructor, OK to reference other objects");
            }
            // Cleanup delle risorse non gestite
            Console.WriteLine("Disposing...");
        }
        is_disposed = true; // Segna l'oggetto come già rilasciato
    }

    // Implementazione del metodo Dispose di IDisposable
    public void Dispose()
    {
        Dispose(true); // Cleanup completo (risorse gestite e non)
        GC.SuppressFinalize(this); // Evita il richiamo del distruttore
    }

    // Distruttore
    ~Testing()
    {
        Dispose(false); // Cleanup parziale (solo risorse non gestite)
        Console.WriteLine("In destructor.");
    }
}
