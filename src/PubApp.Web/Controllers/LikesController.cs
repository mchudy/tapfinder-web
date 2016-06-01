﻿using Microsoft.AspNet.Identity;
using PubApp.Web.Dtos;
using PubApp.Web.Services;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [Authorize]
    [RoutePrefix("")]
    public class LikesController : ApiController
    {
        private readonly LikesService service;

        public LikesController(LikesService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("rating")]
        public IHttpActionResult GetRating([FromUri] int itemId)
        {
            var dto = service.GetRating(itemId);
            if (dto == null)
            {
                return BadRequest();
            }
            return Ok(dto);
        }

        [HttpPut]
        [Route("likes")]
        public IHttpActionResult UpdateLike(LikeDto dto)
        {
            if (service.UpdateLike(dto, User.Identity.GetUserId<int>()))
            {
                return Ok();
            }
            service.AddLike(dto, User.Identity.GetUserId<int>());
            string location = Request.RequestUri + "/";
            return Created(location, "");
        }
    }
}