using PubApp.Web.Services;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [RoutePrefix("beers")]
    public class BeersController : ApiController
    {
        private readonly BeersService service;

        public BeersController(BeersService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBeerDetails(int id)
        {
            var beer = service.GetBeerDetails(id);
            if (beer == null)
            {
                return NotFound();
            }
            return Ok(beer);
        }

        [HttpGet]
        [Route("styles")]
        public IHttpActionResult GetAllBeerStyles()
        {
            var styles = service.GetAllBeerStyles();
            return Ok(styles);
        }

        [HttpGet]
        [Route("search")]
        public IHttpActionResult FindBeers(string query)
        {
            var beers = service.FindBeers(query);
            return Ok(beers);
        }
    }
}
