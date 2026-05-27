using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class AbstractClass
    {
        [Required(ErrorMessage = "Il telefono è obbligatorio.")]
        [Phone(ErrorMessage = "Il numero di telefono inserito non è valido.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Lo username è obbligatorio.")]
        public string Citta { get; set; }
        

        public AbstractClass(string telefono, string citta)
        {
            Telefono = telefono;
            Citta = citta;
        }

        public string GetTelefono() => Telefono;
        public string GetCitta() => Citta;

        public string SetTelefono(string telefono) => Telefono = telefono;
        public string SetCitta(string citta) => Citta = citta;
    }
}
