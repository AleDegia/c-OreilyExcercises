using Models;
using Dal;

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


	    public List<Ristorante> GetRistorantiFiltrati(string? citta, string? tipologia, double? prezzo)
        {
            List<Ristorante> ristoranti = dal.GetRistoranti();  //passare filtri al dal
            if (citta != null)
            {
                foreach (Ristorante ristorante in ristoranti)
                {
                    //if (ristorante.Citta = citta)
                    //{
                    //    ristorantiFiltrati.Add(ristorante);
                    //}
                }
                return ristorantiFiltrati;
            }
            else
            {
                // MessageBox.Show($"non ci sono ristoranti a {citta}"); 
    
                return null;
            }
        }


        public Ristorante GetRistorante(int id)
        {
            dal.GetRistorante(id);
            return null;
        }

        public void AggiungiRistorante(Ristorante ristorante)
        {
            dal.AggiungiRistorante(ristorante);
        }

        public void ModificaRistorante(Ristorante ristorante)
        {
            dal.ModificaRistorante(ristorante);
        }

        public void CancellaRistorante(int id)
        {
            dal.CancellaRistorante(id);
        }


    }

}
