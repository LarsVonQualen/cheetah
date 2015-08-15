using System.Web.Http;
using Cheetah.Security.Implementation.Utils;
using Cheetah.WebApi.Controllers.Base;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("protected")]
    [CheetahAuthorize]
    public class ProtectedController : ApiController
    {
        [Route("endpoint")]
        [HttpGet]
        public string Endpoint()
        {
            return "Passed";
        }
    }
}