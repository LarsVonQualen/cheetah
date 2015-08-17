using System.Web.Http;
using Cheetah.DataAccess.Models;
using Cheetah.WebApi.Controllers.Base;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ProtectedBaseApiController<int, string>
    {
        [Route("endpoint/{key:int}")]
        [HttpGet]
        public User Endpoint(int key)
        {
            return CurrentUser;
        }
    }
}