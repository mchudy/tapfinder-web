namespace PubApp.DataAccess.Entities
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public int BeerStyleId { get; set; }
        public int BreweryId { get; set; }

        public BeerStyle Style { get; set; }
        public Brewery Brewery { get; set; }
    }
}
