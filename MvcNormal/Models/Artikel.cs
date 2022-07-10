using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
namespace MvcNormal.Models
{
    [Table("Artikel")]
    public class Artikel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
