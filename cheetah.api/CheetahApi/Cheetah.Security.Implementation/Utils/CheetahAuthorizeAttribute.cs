using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Interfaces.Managers;
using Ninject;

namespace Cheetah.Security.Implementation.Utils
{
    public class CheetahAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        [Inject]
        public ILocalUserManager<User, AccessToken, RefreshToken> LocalUserManager { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {            
            var request = actionContext.Request;
            var auth = request.Headers.Authorization;

            if (auth != null && auth.Scheme.ToLower().Equals("bearer") && !string.IsNullOrEmpty(auth.Parameter))
            {
                var authenticateResult = LocalUserManager.Authenticate(auth.Parameter);

                if (!authenticateResult.IsValid)
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }
    }
}