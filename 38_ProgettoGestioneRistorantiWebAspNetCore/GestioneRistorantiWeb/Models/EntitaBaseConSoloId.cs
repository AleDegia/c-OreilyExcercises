using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //Ci faccio derivare Ristorante e Prenotazione
    public abstract class EntitaBaseConSoloId
    {
        private int Id { get; set; }
    }
}
