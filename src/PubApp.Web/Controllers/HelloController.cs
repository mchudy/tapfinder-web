using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PubApp.DataAccess;
using PubApp.DataAccess.Entities;
using PubApp.Web.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [RoutePrefix("hello")]
    public class HelloController : ApiController
    {
        private readonly ApplicationContext ctx;
        private readonly UserManager<User, int> userManager;
        private readonly IAuthenticationManager authenticationManager;

        public HelloController(ApplicationContext ctx, ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
        {
            this.ctx = ctx;
            this.userManager = userManager;
            this.authenticationManager = authenticationManager;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(ctx.Users.Count());
        }

        [HttpGet]
        [Route("register")]
        public async Task<IHttpActionResult> Register()
        {
            //var user = new User { UserName = "user", Email = "a@gmail.com" };
            //IdentityResult result = await userManager.CreateAsync(user, "bbbfff1");
            //if (!result.Succeeded)
            //{
            //    return BadRequest();
            //}
            return Ok();
        }
    }
}
