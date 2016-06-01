namespace PubApp.Web.Dtos
{
    public class LikeDto
    {
        public int LikeableItemId { get; set; }
        public bool Liked { get; set; }
        public string UserName { get; set; }
    }
}