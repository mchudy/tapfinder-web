using System.Web.Http;
using Microsoft.AspNet.Identity;
using TapFinder.Web.Services;

namespace TapFinder.Web.Controllers
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

        [HttpHead]
        [Route("places")]
        public IHttpActionResult CheckIfIsFavorite([FromUri] string placeId)
        {
            int userId = User.Identity.GetUserId<int>();
            if (service.UserFavoriteExists(userId, placeId))
            {
                return Ok();
            }
            return NotFound();
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