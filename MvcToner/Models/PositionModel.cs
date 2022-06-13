namespace MvcToner.Models
{
    public class PositionModel
    {
        public int PrimaryKey { get; set; }
        public BelegModel Bestellung { get; set; }
        public ArtikelModel Artikel { get; set; }
        public int Menge { get; set; } = 1;

        
    }
}
