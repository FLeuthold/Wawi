using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
namespace MvcNormal.Models
{
    [Table("Position")]
    public class Position
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }
        [Required]
        [ForeignKey("ArtikelId")]
        public Artikel Artikel { get; set; }
        public int Menge { get; set; } = 1;
        [Required]
        public int BelegId { get; set; }
        [ForeignKey("BelegId")]
        public Beleg Beleg { get; set; }//Navigation Property

    }
}
