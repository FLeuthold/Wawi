using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcNormal.Models
{
    public class BelegModel
    {
        [Key]
        public int PrimaryKey { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        
        public AdresseModel Adresse { get; set; }

        public BelegModel(AdresseModel adresse)
        {
            Adresse = adresse;
        }

        //public List<PositionModel> Positions { get; set; } = new List<PositionModel>();





    }
}
