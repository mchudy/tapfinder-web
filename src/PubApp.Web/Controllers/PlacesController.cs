using AutoMapper;
using Microsoft.AspNet.Identity;
using PubApp.Web.Dtos;
using PubApp.Web.Services;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [Authorize]
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

        [HttpPost]
        [Route("{id}/specialoffers")]
        public IHttpActionResult AddSpecialOffer(AddSpecialOfferDto dto)
        {
            var offer = service.AddSpecialOffer(dto, User.Identity.GetUserId<int>());
            string location = Request.RequestUri.ToString();
            return Created(location, Mapper.Map<SpecialOfferDto>(offer));
        }

        [HttpGet]
        [Route("{id}/beers")]
        public IHttpActionResult GetBeers(string id)
        {
            var beers = service.GetBeers(id);
            return Ok(beers);
        }

        [HttpPost]
        [Route("{id}/beers")]
        public IHttpActionResult AddBeerOnTap(AddPlaceBeerDto dto)
        {
            var placeBeer = service.GetPlaceBeer(dto.BeerId, dto.PlaceId);
            if (placeBeer != null)
            {
                return Conflict();
            }
            placeBeer = service.AddPlaceBeer(dto, User.Identity.GetUserId<int>());
            string location = Request.RequestUri.ToString();
            return Created(location, Mapper.Map<PlaceBeerDto>(placeBeer));
        }

        [HttpGet]
        [Route("{id}/comments")]
        public IHttpActionResult GetComments(string id)
        {
            var comments = service.GetComments(id);
            return Ok(comments);
        }

        [HttpPost]
        [Route("comments")]
        public IHttpActionResult PostComment(CommentDto dto)
        {
            var commentId = service.AddComment(dto, User.Identity.GetUserId<int>());
            string location = Request.RequestUri + "/" + commentId;
            return Created(location, commentId);
        }
    }
}