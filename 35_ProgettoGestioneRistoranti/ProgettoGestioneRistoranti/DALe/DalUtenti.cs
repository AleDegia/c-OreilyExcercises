using DALe;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    public class DalUtenti
    {
        private DbData<Utente> dbData;

        public DalUtenti()
        {
            dbData = new DbData<Utente>();
        }

        public Utente GetUtente(int id) 
        {
            return null;
        }

        public List<Utente> GetUtenti()
        {
            // Ottengo la lista generica
            List<object> entities = dbData.GetAllEntities();

            // Filtro e casto ogni elemento della lista a Ristorante
            List<Utente> utenti = entities.OfType<Utente>().ToList();

            return utenti;
        }

        public void AggiungiUtente(Utente utente)
        {
            dbData.AggiungiEntity(utente);
        }

        public void ModificaUtente(Utente utente)
        { 
            dbData.ModificaEntity(utente);
        }

        public void CancellaUtente(string username)
        {
            dbData.CancellaEntity(username, "Utenti");
        }


    }
}
