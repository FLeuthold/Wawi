using System.ComponentModel.DataAnnotations;

namespace MvcToner.Models
{
    
    public class BelegModel
    {
        
        [Required]
        public int PrimaryKey { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public AdresseModel Adresse { get; set; }

        //public List<PositionModel> Positions { get; set; } = new List<PositionModel>();

        public BelegModel(AdresseModel adresse)
        {
            Adresse = adresse;
        }



    }
}
