using Ninject;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories;
using Cheetah.Security.Interfaces.Models;
using Ninject.Modules;

namespace Cheetah.DataAccess
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PetaPoco.Database>()
                .To(typeof(PetaPoco.Database))
                .InThreadScope()
                .WithConstructorArgument("connectionStringName", "CheetahPocoModel");

            Bind<IUserRepository>()
                .To<UserRepository>()
                .InThreadScope();

            Bind<IPasswordHashRepository>()
                .To<PasswordHashRepository>()
                .InThreadScope();

            Bind<IAccessTokenRepository>()
                .To<AccessTokenRepository>()
                .InThreadScope();

            Bind<ITokenRepository<AccessToken>>()
                .To<AccessTokenRepository>();

            Bind<IRefreshTokenRepository>()
                .To<RefreshTokenRepository>()
                .InThreadScope();

            Bind<ITokenRepository<RefreshToken>>()
                .To<RefreshTokenRepository>();
        }
    }
}