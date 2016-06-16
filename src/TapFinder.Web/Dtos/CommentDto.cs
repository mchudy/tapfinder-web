using System;

namespace TapFinder.Web.Dtos
{
    public class CommentDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string PlaceId { get; set; }
        public string UserName { get; set; }
    }
}