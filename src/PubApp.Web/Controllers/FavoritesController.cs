using Microsoft.AspNet.Identity;
using PubApp.Web.Services;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [Authorize]
    [RoutePrefix("favorites")]
    public class FavoritesController : ApiController
    {
        private readonly FavoritesService service;

        public FavoritesController(FavoritesService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("places")]
        public IHttpActionResult AddFavouritePlace([FromUri] string placeId)
        {
            int userId = User.Identity.GetUserId<int>();
            if (!service.AddFavouritePlace(userId, placeId))
            {
                return Conflict();
            }
            string location = Request.RequestUri.ToString();
            return Created(location, new { placeId, userId });
        }

        [HttpDelete]
        [Route("places")]
        public IHttpActionResult DeleteFavouritePlace([FromUri] string placeId)
        {
            int userId = User.Identity.GetUserId<int>();
            if (!service.DeleteFavoritePlace(userId, placeId))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}