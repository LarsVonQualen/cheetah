using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Implementation.Models;
using Cheetah.Security.Interfaces.Managers;
using Cheetah.Security.Interfaces.Models;
using Cheetah.WebApi.Controllers.Base;
using Cheetah.WebApi.Models;
using Microsoft.Owin.Security;
using Ninject;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : BaseApiController<Guid, User>
    {
        [Inject]
        public ILocalUserManager<User, AccessToken, RefreshToken> LocalUserManager { get; set; }

        /// <summary>
        /// Should register the user...
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public UserInfoViewModel Register(UserViewModel user)
        {
            var newUser = LocalUserManager.Create(user.Info, user.Password);
            var refreshToken = LocalUserManager.RefreshTokenStore.Find(newUser.UserId);

            return new UserInfoViewModel()
            {
                User = newUser,
                RefreshToken = refreshToken
            };
        }

        /// <summary>
        /// Should look at the authorization header and find the user from that.
        /// </summary>
        /// <returns></returns>
        [Route("me")]
        [HttpGet]
        public UserInfoViewModel Me()
        {
            var userAccessToken = ActionContext.Request.Headers.Authorization.Parameter;
            var accessToken = LocalUserManager.AccessTokenStore.Find(userAccessToken);

            if (accessToken == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            var user = LocalUserManager.UserStore.Find(accessToken.UserId);
            var refreshToken = LocalUserManager.RefreshTokenStore.Find(user.UserId);

            return new UserInfoViewModel()
            {
                User = user,
                RefreshToken = refreshToken
            };
        }

        /// <summary>
        /// Should take some sort of request defining whether to use an ExternalLogin or
        /// local login, in the form of a username and password.
        /// 
        /// Then return some sort authorization grant, with a client id and refresh token?!
        /// </summary>
        /// <param name="authRequest"></param>
        /// <returns></returns>
        [Route("authorize")]
        [HttpPost]
        public IAuthorizationGrant Authorize(LocalAuthRequest authRequest)
        {
            return LocalUserManager.Authorize(authRequest);
        }

        /// <summary>
        /// Should take a refresh request consisting of a client id and refresh token, then
        /// it should return some sort of object that holds the access token.
        /// </summary>
        /// <param name="refreshRequest"></param>
        /// <returns></returns>
        [Route("refresh")]
        [HttpPost]
        public AccessToken Refresh(RefreshRequest refreshRequest)
        {
            return LocalUserManager.Refresh(refreshRequest);
        }

        /// <summary>
        /// Should take the access token and return some sort of object that tells whether it
        /// is a valid user or not. Should not necessarily be used, but would be nice to be
        /// able to explicit check the access token.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [Route("authenticate/{accessToken:alpha}")]
        [HttpGet]
        public IAuthenticationResponse Authenticate(string accessToken)
        {
            return LocalUserManager.Authenticate(accessToken);
        }
    }
}