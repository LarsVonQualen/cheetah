using Cheetah.DataAccess.Models;
using Cheetah.WebApi.Identity;
using Microsoft.AspNet.Identity;
using Ninject.Modules;

namespace Cheetah.WebApi
{
    public class RuntimeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPetaPocoUserStore>()
                .To<PetaPocoUserStore>()
                .InThreadScope();            
        }
    }
}