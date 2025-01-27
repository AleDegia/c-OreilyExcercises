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
    }
}
