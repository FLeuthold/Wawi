using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcNormal.Models
{
    public class AdresseModel
    {
        [Key]
        public int PrimaryKey { get; set; }
        
        public string Name { get; set; }
    }
}
