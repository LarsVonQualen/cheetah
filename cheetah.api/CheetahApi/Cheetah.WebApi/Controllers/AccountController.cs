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
using Cheetah.Security.Implementation.Exceptions;
using Cheetah.Security.Implementation.Models;
using Cheetah.Security.Interfaces.Managers;
using Cheetah.Security.Interfaces.Models;
using Cheetah.WebApi.Controllers.Base;
using Cheetah.WebApi.Models;
using Microsoft.Owin.Security;
using Ninject;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("v1/account")]
    public class AccountController : BaseController
    {        
        /// <summary>
        /// Registers a new user
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
        /// Get the current users details
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
        /// Takes a LocalAuthRequests, verifies it and returns a AuthorizationGrant
        /// </summary>
        /// <param name="authRequest"></param>
        /// <returns></returns>
        [Route("authorize")]
        [HttpPost]
        public IAuthorizationGrant Authorize(LocalAuthRequest authRequest)
        {
            try
            {
                return LocalUserManager.Authorize(authRequest);
            }
            catch (InvalidCredentials)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }

        /// <summary>
        /// Takes a RefreshRequest and if valid returns a new AccessToken
        /// </summary>
        /// <param name="refreshRequest"></param>
        /// <returns></returns>
        [Route("refresh")]
        [HttpPost]
        public AccessToken Refresh(RefreshRequest refreshRequest)
        {
            try
            {
                return LocalUserManager.Refresh(refreshRequest);
            }
            catch (InvalidRefreshToken)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        /// <summary>
        /// Takes an AccessToken and verifies that it is valid
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [Route("authenticate")]
        [HttpPost]
        public IAuthenticationResponse Authenticate(AccessToken accessToken)
        {
            try
            {
                return LocalUserManager.Authenticate(accessToken.Token);
            }
            catch (InvalidAccessToken)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            catch (AccessTokenExpired)
            {
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }
        }

        [Route("revoke/{userId:guid}")]
        [HttpGet]
        public void Revoke(Guid userId)
        {
            try
            {
                var user = LocalUserManager.UserStore.Find(userId);

                LocalUserManager.Revoke(user);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}