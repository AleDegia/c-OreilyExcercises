
namespace Domain.Entities;

public class Ristorante
{
    public int Id { get; set; }

    public int TipologiaId { get; set; }

    public string RagioneSociale { get; set; } = string.Empty;

    public string PartitaIva { get; set; } = string.Empty;

    public string Indirizzo { get; set; } = string.Empty;

    public string Citta { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public int NumeroPosti { get; set; }

    public decimal PrezzoMedio { get; set; }
}
