using Models;
using Dal;
using System.Collections.Generic;

namespace BLLL
{
    public class BlUtenti
    {
        private DalUtenti dal;
        public BlUtenti()
        {
            dal = new DalUtenti();
        }

        public Utente GetUtente(string username)
        {
           return dal.GetUtente(username);
        }

        public List<Utente> GetUtenti()
        {
            List<Utente> utenti = dal.GetUtenti();
            return utenti;
        }
        public void AggiungiUtente(Utente utente)
        {
            dal.AggiungiUtente(utente);
        }

        public void ModificaUtente(Utente utente)
        {
            dal.ModificaUtente(utente);
        }

        public void CancellaUtente(string username)
        {
            dal.CancellaUtente(username);
        }
    }
}
