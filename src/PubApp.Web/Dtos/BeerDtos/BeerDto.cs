namespace PubApp.Web.Dtos
{
    public class BeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public int StyleId { get; set; }
        public BreweryDto Brewery { get; set; }
    }
}