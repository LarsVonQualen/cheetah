using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Implementation.Utils;
using Cheetah.Security.Interfaces.Managers;
using Cheetah.WebApi.Controllers.Base;
using Cheetah.WebApi.Models;
using Ninject;

namespace Cheetah.WebApi.Controllers.Base
{
    [CheetahAuthorize]
    public class ProtectedBaseApiController<TKey, TValue> : BaseApiController<TKey, TValue>
    {
        [Inject]
        public ILocalUserManager<User, AccessToken, RefreshToken> LocalUserManager { get; set; }

        protected User CurrentUser { get; set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            CurrentUser = null;

            var authHeader = controllerContext.Request.Headers.Authorization;

            var authParam = authHeader?.Parameter;

            if (authParam == null)
                return;

            var accessToken = LocalUserManager.AccessTokenStore.Find(authParam);

            if (accessToken == null)
                return;

            var user = LocalUserManager.UserStore.Find(accessToken.UserId);

            if (user == null)
                return;

            CurrentUser = user;
        }
    }
}