using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcNormal.Models
{
    [Table("Beleg")]
    public class Beleg
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public int AdresseId { get; set; }
        [ForeignKey("AdresseId")]
        public Adresse Adresse { get; set; }//Navigation Property
        public List<Position> Positionen { get; set; } = new List<Position>();

    }
}
