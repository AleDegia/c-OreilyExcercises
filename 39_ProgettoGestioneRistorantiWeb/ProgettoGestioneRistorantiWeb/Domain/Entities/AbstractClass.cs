using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public abstract class AbstractClass
{
    [Phone]
    public string Telefono { get; set; } = string.Empty;

    public string Citta { get; set; } = string.Empty;
}
