using System.Collections.Generic;

namespace PubApp.Web.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string ImagePath { get; set; }
        public RankDto Rank { get; set; }
        public IList<BadgeDto> Badges { get; set; }
    }
}