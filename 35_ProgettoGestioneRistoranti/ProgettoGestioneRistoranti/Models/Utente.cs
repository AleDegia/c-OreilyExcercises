using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Utente : AbstractClass
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdministrator { get; set; }
        public string Descrizione { get; set; }
        public string Email { get; set; }

        public Utente(string userName, string password, bool isAdministrator, string descrizione, string email, string Telefono, string Citta) : base (Telefono, Citta)
        {
            UserName = userName;
            Password = password;
            IsAdministrator = isAdministrator;
            Descrizione = descrizione;
            Email = email;
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
