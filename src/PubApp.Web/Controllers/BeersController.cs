using AutoMapper.QueryableExtensions;
using PubApp.Web.Dtos;
using PubApp.Web.Services;
using System.Linq;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [Authorize]
    [RoutePrefix("beers")]
    public class BeersController : ApiController
    {
        private readonly BeersService service;

        public BeersController(BeersService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("styles")]
        public IHttpActionResult GetAllBeerStyles()
        {
            var styles = service.GetAllBeerStyles();
            var dtos = styles.ProjectTo<BeerStyleDto>().ToList();
            return Ok(dtos);
        }
    }
}
