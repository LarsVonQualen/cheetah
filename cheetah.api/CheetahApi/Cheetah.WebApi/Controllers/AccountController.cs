using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.WebApi.Controllers.Base;
using Microsoft.Owin.Security;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : BaseApiController<Guid, User>
    {
        /// <summary>
        /// Should register the user...
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public object Register(object user)
        {
            throw new NotImplementedException();
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
        public object Authorize(object authRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Should take a refresh request consisting of a client id and refresh token, then
        /// it should return some sort of object that holds the access token.
        /// </summary>
        /// <param name="refreshRequest"></param>
        /// <returns></returns>
        [Route("refresh")]
        [HttpPost]
        public object Refresh(object refreshRequest)
        {
            throw new NotImplementedException();
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
        public object Authenticate(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}