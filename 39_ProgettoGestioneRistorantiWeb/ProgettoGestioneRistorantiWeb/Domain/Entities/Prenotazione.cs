using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Prenotazione
{
    public int Id { get; set; }

    public int RistoranteId { get; set; }

    public string NomeUtente { get; set; } = string.Empty;

    public DateTime DataRichiesta { get; set; }

    public DateTime DataPrenotazione { get; set; }

    [Range(1, int.MaxValue)]
    public int NumeroPersone { get; set; }
}
