
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

    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
    public decimal PrezzoMedio { get; set; }
}
