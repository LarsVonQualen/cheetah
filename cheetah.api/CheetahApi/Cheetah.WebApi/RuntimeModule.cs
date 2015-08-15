using Cheetah.DataAccess.Models;
using Cheetah.Security.Implementation.Managers;
using Cheetah.Security.Interfaces.Managers;
using Ninject.Modules;

namespace Cheetah.WebApi
{
    public class RuntimeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILocalUserManager<User, AccessToken, RefreshToken>>()
                .To<LocalUserManager>()
                .InThreadScope();
        }
    }
}