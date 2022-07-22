using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcNormal.Models
{
    /**
     * Belegarten
     * -  Bestellung (mit Wareneingang)
     * -  Auftrag (mit Status)
     * -  Inventur
     */
    [Table("Beleg")]
    public class Beleg
    {
        public string ErfUser { get; set; }
        public string MutUser { get; set; }
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public int AdresseId { get; set; }
        [ForeignKey("AdresseId")]
        public Adresse Adresse { get; set; }//Navigation Property
        [InverseProperty("Beleg")]
        public List<Position> Positionen { get; set; } = new List<Position>();

    }
}
