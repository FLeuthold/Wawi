using System.ComponentModel.DataAnnotations;

namespace MvcToner.Models
{
    public class BestellungModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public AdresseModel Adresse { get; set; } = new AdresseModel();

        public List<PositionModel> Positions { get; set; } = new List<PositionModel>();





    }
}
