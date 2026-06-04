using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("Tipologia")]
    public class Tipologie
    {
        [Key]
        public int Tipologia { get; set; }
        public string Descrizione { get; set; }
    }
}
