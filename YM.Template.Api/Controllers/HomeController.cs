using System.Threading.Tasks;
using System.Web.Http;

namespace YM.Template.Api.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {

        [Route("")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Get()
        {
            return await Task.Run(() => Ok());
        }

        [Route("authorisedroute")]
        [Authorize]
        public async Task<IHttpActionResult> AuthorisedRoute()
        {
            return await Task.Run(() => Ok());
        }

    }
}
