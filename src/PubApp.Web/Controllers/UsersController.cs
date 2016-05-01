using Microsoft.AspNet.Identity;
using PubApp.Web.Dtos;
using PubApp.Web.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> RegisterUser(UserRegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await usersService.RegisterUser(dto))
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        [Route("password")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await usersService.ChangePassword(dto, User.Identity.GetUserId<int>()))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
