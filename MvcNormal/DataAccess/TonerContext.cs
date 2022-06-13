using System;
using System.Collections.Generic;

using MvcNormal.Models;

namespace MvcNormal.Data
{
    public class TonerContext
    {

        public List<AdresseModel> Adressen { get; set; }
        public List<BelegModel> Bestellungen { get; set; }
        public List<ArtikelModel> Artikel { get; set; }

        public List<PositionModel> Positions { get; set; }
        public TonerContext()
        {
            Positions = new List<PositionModel>();
            Bestellungen = new List<BelegModel>();
            AdresseModel gzsz = new AdresseModel() { PrimaryKey = 2, Name = "GZSZ" };
            Adressen = new List<AdresseModel> { gzsz };
            var gzszbeleg = new BelegModel(gzsz) { PrimaryKey = 1, Datum = DateTime.Now };
            Bestellungen.Add(gzszbeleg);
            var cf410 = new ArtikelModel() { PrimaryKey = 1, Name = "CF410" };
            var cf400 = new ArtikelModel() { PrimaryKey = 2, Name = "CF400" };
            var cf401 = new ArtikelModel() { PrimaryKey = 3, Name = "CF401" };
            Positions.Add(new PositionModel() { PrimaryKey = 1, Artikel = cf410 });
            //string sql = "";
            //var bestellungen = SqlDataAccess.LoadData<BestellungModel>(sql);
            Artikel = new List<ArtikelModel>
            {
                cf400,
                cf401,
                cf410
            };
        }
    }
}
