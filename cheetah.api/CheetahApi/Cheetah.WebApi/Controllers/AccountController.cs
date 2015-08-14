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
using Cheetah.WebApi.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("account")]
    [System.Web.Mvc.Authorize]
    public class AccountController : BaseApiController<Guid, User>
    {
        public UserManager<User> UserManager { get; private set; }

        public AccountController(
            IPetaPocoUserStore petaPocoUserStore
            ) : this(new UserManager<User>(petaPocoUserStore))
        {
            
        }

        private AccountController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }               
    }
}