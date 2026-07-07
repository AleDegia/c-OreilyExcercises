using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PrenotazioneListItem
    {
        public int Id { get; set; }
        public String Testo { get; set; }
        public override string ToString()
        {
            return Testo;
        }
    }
}
