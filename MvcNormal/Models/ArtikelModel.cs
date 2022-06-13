using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace MvcNormal.Models
{
    public class ArtikelModel
    {
        [Key]
        public int PrimaryKey { get; set; }
        public string Name { get; set; }
    }
}
