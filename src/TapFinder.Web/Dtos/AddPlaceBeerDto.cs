namespace TapFinder.Web.Dtos
{
    public class AddPlaceBeerDto
    {
        public int BeerId { get; set; }
        public string PlaceId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}