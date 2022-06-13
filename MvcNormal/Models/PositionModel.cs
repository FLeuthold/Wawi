using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace MvcNormal.Models
{
    public class PositionModel
    {
        [Key]
        public int PrimaryKey { get; set; }
        public BelegModel Beleg { get; set; }
        public ArtikelModel Artikel { get; set; }
        public int Menge { get; set; } = 1;

        
    }
}
