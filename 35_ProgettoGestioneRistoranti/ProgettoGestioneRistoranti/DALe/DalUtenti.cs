using DALe;
using Models;
using System;
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

        public Utente GetUtente(string username) 
        {
            //per prendere la propagazione dell'errore da dbData
            try
            {
                return dbData.GetUtente(username);
            }
            catch (Exception ex)
            {
                // Loggare o gestire l'errore, ad esempio:
                Console.WriteLine("Errore durante il recupero dell'utente: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public List<Utente> GetUtenti()
        {
            try
            {
                // Ottengo la lista generica
                List<object> entities = dbData.GetAllEntities();

                // Filtro e casto ogni elemento della lista a Ristorante
                List<Utente> utenti = entities.OfType<Utente>().ToList();

                return utenti;
            }
            catch (Exception ex)
            {
                // Loggare o gestire l'errore, ad esempio:
                Console.WriteLine("Errore durante il recupero degli utenti: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public void AggiungiUtente(Utente utente)
        {
            try
            {
                dbData.AggiungiEntity(utente);
            }
            catch (Exception ex)
            {
                // Loggare o gestire l'errore, ad esempio:
                Console.WriteLine("Errore durante l'inserimento dell'utente: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
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
