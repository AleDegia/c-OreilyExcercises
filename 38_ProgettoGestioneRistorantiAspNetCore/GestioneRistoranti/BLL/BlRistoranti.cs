using Dal;
using DALe;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Engine
{
    public class BlRistoranti
    {
        private List<Ristorante> ristorantiFiltrati;
        private GestioneRistorantiContext context;

        public BlRistoranti()
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json", optional: false)
              .Build();

            var connectionString = configuration.GetConnectionString(
            "GestioneRistorantiConnectionString"
        );

            var options = new DbContextOptionsBuilder<GestioneRistorantiContext>()
       .UseSqlServer(connectionString)
       .Options;

            context = new GestioneRistorantiContext(options);
        }

        Dictionary<string, int> tipologieRistorante = new Dictionary<string, int>()
        {
            { "italiano", 1 },
            { "giapponese", 2 },
            { "cinese", 3 },
            { "messicano", 4 },
            { "fastFood", 5 }
        };


        public List<Ristorante> GetRistorantiFiltrati()
        {
            try
            {
                // Ottengo la lista generica
                List<Ristorante> ristoranti = context.Ristoranti.ToList<Ristorante>();
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
                return context.Ristoranti.Find(id);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Errore durante il recupero del ristorante: " + ex.Message);
                throw;  // Rilancia l'eccezione per propagarla ulteriormente
            }
        }

        public void AggiungiRistorante(Ristorante ristorante)
        {
            context.Ristoranti.Add(ristorante);
            context.SaveChanges();
        }

        public void ModificaRistorante(Ristorante ristorante)
        {
            context.Update(ristorante);
            context.SaveChanges();
        }

        public void CancellaRistorante(Ristorante ristorante)
        {
            Ristorante rist = context.Ristoranti.Find(ristorante.IDRistorante);
            context.Remove(rist);
            context.SaveChanges();
        }

        public List<Ristorante> GetRistorantiFiltrati2(string filtro, string inputUtente)
        {
            //recupero tutti i ristoranti
            IQueryable<Ristorante> query = context.Ristoranti;

            switch (filtro)
            {
                case "Tipologia":
                    int tipologia = tipologieRistorante[inputUtente.ToLower()];
                    query = query.Where(r => r.Tipologia == tipologia); //filtro per tipologia
                    break;

                case "Citta":
                    query = query.Where(r => r.Citta == inputUtente);
                    break;

                case "Prezzo":
                    string prezzo = inputUtente.Replace(",", ".");

                    decimal prezzoMedio = Convert.ToDecimal(
                        prezzo,
                        CultureInfo.InvariantCulture
                    );

                    query = query.Where(r => r.PrezzoMedio == prezzoMedio);
                    break;

                default:
                    return new List<Ristorante>();
            }

            return query.ToList();
        }

        public DataTable GetDatiElencoRistoranti()
        {
            var result =
               from r in context.Ristoranti
               join t in context.Tipologie
                   on r.Tipologia equals t.Tipologia into tipologie
               from t in tipologie.DefaultIfEmpty()
               select new      //faccio new perche devo fare nuovo ogg con i campi che mi servono, non posso fare select r perche mi da tutti i campi di ristorante senza il nome della tipologia, invece con new posso fare un oggetto anonimo con i campi di ristorante e aggiungere il campo della tipologia
               {
                   r.IDRistorante,
                   r.Tipologia,
                   r.NumPosti,
                   r.PartitaIva,
                   r.RagioneSociale,
                   r.Indirizzo,
                   r.Citta,
                   r.Telefono,
                   TipoRistorante = t != null ? t.Descrizione : null
               };

            DataTable dt = new DataTable();

            dt.Columns.Add("IdRistorante", typeof(int));
            dt.Columns.Add("Tipologia", typeof(string));
            dt.Columns.Add("NumPosti", typeof(int));
            dt.Columns.Add("PartitaIva", typeof(string));
            dt.Columns.Add("RagioneSociale", typeof(string));
            dt.Columns.Add("Indirizzo", typeof(string));
            dt.Columns.Add("Citta", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("TipoRistorante", typeof(string));

            foreach (var item in result.ToList())
            {
                dt.Rows.Add(
                    item.IDRistorante,
                    item.Tipologia,
                    item.NumPosti,
                    item.PartitaIva,
                    item.TipoRistorante,
                    item.RagioneSociale,
                    item.Indirizzo,
                    item.Citta,
                    item.Telefono
                );
            }

            return dt;
        }

        public Dictionary<string, decimal> GetGuadagniPerMese2024()
        {
            var risultati =
                from p in context.Prenotazioni
                where p.DataPrenotazione.Year == 2024
                join r in context.Ristoranti on p.IDRistorante equals r.IDRistorante
                select new
                {
                    MeseAnno = p.DataPrenotazione,
                    GuadagnoMensile = r.PrezzoMedio * p.NumPersone
                }
                into x
                group x by x.MeseAnno into g        //into g dà un nome ai gruppi.
                select new
                {
                    MeseAnno = g.Key,               //g.key = x.MeseAnno
                    GuadagnoMensile = g.Sum(x => x.GuadagnoMensile)
                };
            return risultati.ToDictionary(x => x.MeseAnno.ToString("MMMM yyyy"), x => x.GuadagnoMensile);
        }

        public Dictionary<string, decimal> GetGuadagniPerMeseRistorante(int id)
        {
            var risultati =
                    from p in context.Prenotazioni
                    where p.DataPrenotazione.Year == 2024 && p.IDRistorante == id
                    join r in context.Ristoranti on p.IDRistorante equals r.IDRistorante
                    select new
                    {
                        MeseAnno = p.DataPrenotazione,
                        GuadagnoMensile = r.PrezzoMedio * p.NumPersone
                    }
                    into x
                    group x by x.MeseAnno into g        //into g dà un nome ai gruppi.
                    select new
                    {
                        MeseAnno = g.Key,               //g.key = x.MeseAnno
                        GuadagnoMensile = g.Sum(x => x.GuadagnoMensile)
                    };
            return risultati.ToDictionary(x => x.MeseAnno.ToString("MMMM yyyy"), x => x.GuadagnoMensile);
        }
    }
}
