using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Utente : AbstractClass
{
    [MinLength(4)]
    public string UserName { get; set; } = string.Empty;

    [MinLength(8)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$")]
    public string Password { get; set; } = string.Empty;

    public bool IsAdministrator { get; set; }

    public string Descrizione { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
