
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Ristorante : AbstractClass
{
    public int Id { get; set; }

    public int TipologiaId { get; set; }

    public string RagioneSociale { get; set; } = string.Empty;

    public string PartitaIva { get; set; } = string.Empty;

    public string Indirizzo { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int NumeroPosti { get; set; }

    [Range(0.01, 10000)]
    public decimal PrezzoMedio { get; set; }
    public string? UsernameProprietario { get; set; }
    public byte[]? Immagine { get; set; }
}
