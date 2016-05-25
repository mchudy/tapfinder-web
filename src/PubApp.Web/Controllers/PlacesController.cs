using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [Authorize]
    [RoutePrefix("place")]
    public class PlacesController : ApiController
    {
        [HttpGet]
        [Route("{id}/specialoffers")]
        public IHttpActionResult GetSpecialOffers(string id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/beers")]
        public IHttpActionResult GetBeers(string id)
        {
            return Ok();
        }
    }
}