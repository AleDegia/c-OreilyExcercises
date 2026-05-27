using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Utente : AbstractClass
    {
        [Required(ErrorMessage = "Lo username è obbligatorio.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "The username value must be between 4 and 20 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La password è obbligatoria.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La password deve essere lunga almeno 8 caratteri.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$",
        ErrorMessage = "La password deve contenere almeno una lettera, un numero e un carattere speciale.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "il tipo è obbligatorio.")]
        public bool IsAdministrator { get; set; }
        [StringLength(10, ErrorMessage = "La descrizione deve essere di almeno 10 caratteri.")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = "L'email è obbligatoria.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Utente(string userName, string password, bool isAdministrator, string descrizione, string email, string Telefono, string Citta) : base (Telefono, Citta)
        {
            UserName = userName;
            Password = password;
            IsAdministrator = isAdministrator;
            Descrizione = descrizione;
            Email = email;
        }

        public void Prenota()
        {

        }

        public string GetUserName() => UserName;
        public void SetUserName(string value) => UserName = value;

        public string GetPassword() => Password;
        public void SetPassword(string value) => Password = value;

        public bool GetIsAdministrator() => IsAdministrator;
        public void SetIsAdministrator(bool value) => IsAdministrator = value;

        public string GetDescrizione() => Descrizione;
        public void SetDescrizione(string value) => Descrizione = value;

        public string GetEmail() => Email;
        public void SetEmail(string value) => Email = value;

        
    }
}
