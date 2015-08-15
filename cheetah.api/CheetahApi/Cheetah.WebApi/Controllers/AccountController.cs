using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Interfaces.Managers;
using Cheetah.Security.Interfaces.Models;
using Cheetah.WebApi.Controllers.Base;
using Cheetah.WebApi.Models;
using Microsoft.Owin.Security;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : BaseApiController<Guid, User>
    {
        private readonly ILocalUserManager<User, AccessToken, RefreshToken> _localUserManager;

        public AccountController(
            ILocalUserManager<User, AccessToken, RefreshToken> localUserManager
            )
        {
            _localUserManager = localUserManager;
        }

        /// <summary>
        /// Should register the user...
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public async Task<RefreshToken> Register(UserViewModel user)
        {
            return await _localUserManager.CreateAsync(user.Info, user.Password);
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
        public Task<IAuthorizationGrant> Authorize(ILocalAuthRequest authRequest)
        {
            return _localUserManager.AuthorizeAsync(authRequest);
        }

        /// <summary>
        /// Should take a refresh request consisting of a client id and refresh token, then
        /// it should return some sort of object that holds the access token.
        /// </summary>
        /// <param name="refreshRequest"></param>
        /// <returns></returns>
        [Route("refresh")]
        [HttpPost]
        public Task<AccessToken> Refresh(IRefreshRequest<RefreshToken> refreshRequest)
        {
            return _localUserManager.RefreshAsync(refreshRequest);
        }

        /// <summary>
        /// Should take the access token and return some sort of object that tells whether it
        /// is a valid user or not. Should not necessarily be used, but would be nice to be
        /// able to explicit check the access token.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [Route("authenticate/{accessToken:string}")]
        [HttpGet]
        public Task<IAuthenticationResponse> Authenticate(string accessToken)
        {
            return _localUserManager.AuthenticateAsync(accessToken);
        }
    }
}