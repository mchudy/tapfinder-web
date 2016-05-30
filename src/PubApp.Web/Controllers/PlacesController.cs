using PubApp.Web.Services;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    //[Authorize]
    [RoutePrefix("places")]
    public class PlacesController : ApiController
    {
        private readonly PlacesService service;

        public PlacesController(PlacesService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{id}/specialoffers")]
        public IHttpActionResult GetSpecialOffers(string id)
        {
            var offers = service.GetSpecialOffers(id);
            return Ok(offers);
        }

        [HttpGet]
        [Route("{id}/beers")]
        public IHttpActionResult GetBeers(string id)
        {
            var beers = service.GetBeers(id);
            return Ok(beers);
        }
        
        [HttpGet]
        [Route("{id}/comments")]
        public IHttpActionResult GetComments(string id)
        {
            var comments = service.GetComments(id);
            return Ok(comments);
        }
    }
}