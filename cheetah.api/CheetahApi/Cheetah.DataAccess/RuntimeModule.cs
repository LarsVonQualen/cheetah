using Ninject;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories;
using Ninject.Modules;

namespace Cheetah.DataAccess
{
    public class RuntimeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PetaPoco.Database>()
                .To<PetaPoco.Database>()
                .InThreadScope()
                .WithConstructorArgument("connectionString", "CheetahPocoModel");
            
            Bind<IUserRepository>()
                .To<UserRepository>()
                .InThreadScope();

            Bind<IPasswordHashRepository>()
                .To<PasswordHashRepository>()
                .InThreadScope();

            Bind<IAccessTokenRepository>()
                .To<AccessTokenRepository>()
                .InThreadScope();

            Bind<IRefreshTokenRepository>()
                .To<RefreshTokenRepository>()
                .InThreadScope();
        }
    }
}