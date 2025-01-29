using Models;
using Dal;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Engine
{
    public class BlRistoranti
    {
        private List<Ristorante> ristorantiFiltrati;
        private DalRistoranti dal;

        public BlRistoranti()
        {
            dal = new DalRistoranti();
        }


	    public List<Ristorante> GetRistorantiFiltrati(string citta, string tipologia, double? prezzo)
        {
            List<Ristorante> ristoranti = dal.GetRistoranti();  //passare filtri al dal
            return ristoranti;
        }


        public Ristorante GetRistorante(int id)
        {
            Ristorante ristorante = dal.GetRistorante(id);
            return ristorante;
        }

        public void AggiungiRistorante(Ristorante ristorante)
        {
            dal.AggiungiRistorante(ristorante);
        }

        public void ModificaRistorante(Ristorante ristorante)
        {
            dal.ModificaRistorante(ristorante);
        }

        public void CancellaRistorante(string id, string nomeTabella)
        {
            dal.CancellaRistorante(id, nomeTabella);
        }

        public List<Ristorante> GetRistorantiFiltrati2(string filtro, string input)
        {
            return dal.GetRistorantiFiltrati(filtro, input);
        }
    }

}
