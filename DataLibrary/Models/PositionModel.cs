namespace MvcToner.Models
{
    public class PositionModel
    {
        public int Id { get; set; }
        public ArtikelModel Artikel { get; set; }
        public int Menge { get; set; } = 1;

        
    }
}
