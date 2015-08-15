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

namespace Cheetah.Security.Implementation.Utils
{
    public class CheetahAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private readonly ILocalUserManager<User, AccessToken, RefreshToken> _localUserManager; 

        public CheetahAuthorizeAttribute(
            ILocalUserManager<User, AccessToken, RefreshToken> localUserManager
            )
        {
            _localUserManager = localUserManager;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            var request = actionContext.Request;
            var auth = request.Headers.Authorization;

            if (auth != null && auth.Scheme == "Bearer" && string.IsNullOrEmpty(auth.Parameter))
            {
                if (!_localUserManager.Authenticate(auth.Parameter).IsValid)
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