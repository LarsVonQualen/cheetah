using Cheetah.DataAccess.Models;
using Cheetah.Security.Implementation.Managers;
using Cheetah.Security.Interfaces.Managers;
using Cheetah.WebApi.Controllers;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Cheetah.WebApi
{
    public class WebApiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILocalUserManager<User, AccessToken, RefreshToken>>()
                .To<LocalUserManager>()
                .InThreadScope();
        }
    }
}