using Models;
using Dal;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using System.Data;

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


	    public List<Ristorante> GetRistorantiFiltrati()
        {
            try
            {
                List<Ristorante> ristoranti = dal.GetRistoranti();  //passare filtri al dal
                return ristoranti;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Errore durante il recupero dei ristoranti: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }


        public Ristorante GetRistorante(int id)
        {
            try
            {
                Ristorante ristorante = dal.GetRistorante(id);
                return ristorante;
            }
            catch (Exception ex)
            {
               // Console.WriteLine("Errore durante il recupero del ristorante: " + ex.Message);
                throw;  
            }
        }

        public void AggiungiRistorante(Ristorante ristorante)
        {
            try
            {
                dal.AggiungiRistorante(ristorante);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Errore durante l'aggiunta del ristorante: " + ex.Message);
                throw;  
            }
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

        public DataTable GetDatiElencoRistoranti()
        {
            return dal.GetDatiElencoRistoranti();
        }
    }

}
