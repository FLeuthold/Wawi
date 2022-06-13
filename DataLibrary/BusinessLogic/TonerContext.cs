using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

using MvcToner.Models;

namespace DataLibrary.Data
{
    public class TonerContext
    {
        public TonerContext()
        {
            bestellungen = new List<BestellungModel>();
            AdresseModel adresse = new() { Id = 2, Name = "GZSZ" };
            adressen = new List<AdresseModel> { adresse };
            bestellungen.Add(new BestellungModel() { Id = 1, Datum = DateTime.Now, Adresse = adresse });

            string sql = "";
            var bestellungen = SqlDataAccess.LoadData<BestellungModel>(sql);
            artikel = new List<ArtikelModel>();
        }

        public List<AdresseModel> Adressen
        {
            get { return adressen; }
            set { adressen = value; }
        }

        public List<ArtikelModel> Artikel
        {
            get { return artikel; }
            set { artikel = value; }
        }

        public List<BestellungModel> GetAllOrders()
        {

            return 
        }

        public void AddPosition(ArtikelModel art, int bestID = 0)
        {
            //alle Positionen zur jeweiligen Bestellung mit der ID "bestID"
            var res = bestellungen.FirstOrDefault(x => x.Id == bestID)?.Positions;
            if(res != null)
            {
                PositionModel pos = new PositionModel()
                {
                    Artikel = art,
                    Id = res.Count() + 1
                };
                if (bestID > 0)
                {
                    res.Add(pos);
                }
            }
        }

        
    }
}
