namespace Domain.Entities;

public class Utente
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool IsAdministrator { get; set; }

    public string Descrizione { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public string Citta { get; set; } = string.Empty;
}
