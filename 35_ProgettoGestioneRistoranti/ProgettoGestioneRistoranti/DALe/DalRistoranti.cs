using DALe;
using Models;
using System.Collections.Generic;
using System.Linq;


namespace Dal
{
    public class DalRistoranti
    {

        private DbData<Ristorante> dbData;

        public DalRistoranti()
        {
            dbData = new DbData<Ristorante>();
        }

       
        public Ristorante GetRistorante(int id)
        {
            return dbData.GetEntity(id);
        }
       
        public List<Ristorante> GetRistoranti()
        {
            // Ottengo la lista generica
            List<object> entities = dbData.GetAllEntities();

            // Filtro e casto ogni elemento della lista a Ristorante
            List<Ristorante> ristoranti = entities.OfType<Ristorante>().ToList();

            return ristoranti;
        }

        public void AggiungiRistorante(Ristorante ristorante)
        { 
            dbData.AggiungiEntity(ristorante);
        }

        public void ModificaRistorante(Ristorante ristorante)
        {
            dbData.ModificaEntity(ristorante);
        }

        public void CancellaRistorante(string id, string nomeTabella)
        { 
            dbData.CancellaEntity(id, nomeTabella);
        }

    }
}
