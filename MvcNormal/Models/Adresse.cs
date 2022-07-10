using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MvcNormal.Models
{
    [Table("Adresse")]
    public class Adresse
    {
        public int Id { get; set; }

        [Display]
        public string Name { get; set; }
    }
}
