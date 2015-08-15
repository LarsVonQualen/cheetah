using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Implementation.Managers;
using Cheetah.Security.Implementation.Stores;
using Cheetah.Security.Implementation.Utils;
using Cheetah.Security.Interfaces.Managers;
using Cheetah.Security.Interfaces.Stores;
using Cheetah.Security.Interfaces.Utils;
using Ninject.Modules;

namespace Cheetah.Security.Implementation
{
    public class RuntimeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHasher>()
                .To<Hasher>()
                .InThreadScope();

            Bind<ITokenGenerator>()
                .To<TokenGenerator>()
                .InThreadScope();

            Bind<IPasswordHasher>()
                .To<PasswordHasher>()
                .InThreadScope();

            Bind<ITokenStore<AccessToken>>()
                .To<TokenStore<AccessToken, IAccessTokenRepository>>()
                .InThreadScope();

            Bind<ITokenStore<RefreshToken>>()
                .To<TokenStore<RefreshToken, IRefreshTokenRepository>>()
                .InThreadScope();

            Bind<IUserStore<User>>()
                .To<UserStore>()
                .InThreadScope();

            Bind<ILocalUserManager<User, AccessToken, RefreshToken>>()
                .To<LocalUserManager>()
                .InThreadScope();
        }
    }
}