using Autofac;
using Cheetah.Database.Interfaces;
using Cheetah.Database.Repositories;

namespace Cheetah.Database
{
    public class RuntimeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PetaPoco.Database>()
                .As<PetaPoco.Database>()
                .InstancePerRequest()
                .UsingConstructor(() => new PetaPoco.Database("CheetahPocoModel"));

            builder.RegisterType<ProjectRepository>().As<IProjectRepository>().InstancePerRequest();

            builder.Build();
        }
    }
}