using PubApp.DataAccess;
using System.Web.Http;

namespace PubApp.Web.Controllers
{
    [RoutePrefix("hello")]
    public class HelloController : ApiController
    {
        private readonly ApplicationContext ctx;

        public HelloController(ApplicationContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("hello");
        }
    }
}
