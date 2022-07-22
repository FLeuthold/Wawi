using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcNormal.Models
{
    [Table("Artikel")]
    public class Artikel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Bestand { get; set; } = 0;

        public int Bestellt { get; set; } = 0;
        public int Reserviert { get; set; } = 0;
        public int Mindestbestand { get; set; } = 0;


        public int Verfuegbar
        {
            get { return Bestand - Reserviert; }
        }

        public int Bestellvorschlag
        {
            get { return -Bestand - Bestellt + Mindestbestand + Reserviert; }
        }

    }
}
