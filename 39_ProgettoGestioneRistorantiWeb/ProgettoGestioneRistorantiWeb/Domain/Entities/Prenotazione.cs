namespace Domain.Entities;

public class Prenotazione
{
    public int Id { get; set; }

    public int RistoranteId { get; set; }

    public string NomeUtente { get; set; } = string.Empty;

    public DateTime DataRichiesta { get; set; }

    public DateTime DataPrenotazione { get; set; }

    public int NumeroPersone { get; set; }
}
