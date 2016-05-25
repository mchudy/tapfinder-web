using System;

namespace PubApp.Web.Dtos
{
    public class CommentDto
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string PlaceId { get; set; }
        public string UserName { get; set; }
    }
}