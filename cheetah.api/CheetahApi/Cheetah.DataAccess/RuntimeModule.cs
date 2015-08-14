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

            Bind<IProjectRepository>()
                .To<ProjectRepository>()
                .InThreadScope();

            Bind<ICorporationInterface>()
                .To<CorporationRepository>()
                .InThreadScope();

            Bind<IAddressRepository>()
                .To<AddressRepository>()
                .InThreadScope();

            Bind<ITeamRepository>()
                .To<TeamRepository>()
                .InThreadScope();

            Bind<IUserstoryRepository>()
                .To<UserstoryRepository>()
                .InThreadScope();

            Bind<IOrganizationRepository>()
                .To<OrganizationRepository>()
                .InThreadScope();

            Bind<IFeatureRepository>()
                .To<FeatureRepository>()
                .InThreadScope();

            Bind<ITaskRepository>()
                .To<TaskRepository>()
                .InThreadScope();

            Bind<ISprintReviewRepository>()
                .To<SprintReviewRepository>()
                .InThreadScope();

            Bind<ISprintRetrospectiveRepository>()
                .To<SprintRetrospectiveRepository>()
                .InThreadScope();

            Bind<ISprintRetrospectiveItemRepository>()
                .To<SprintRetrospectiveItemRepository>()
                .InThreadScope();

            Bind<ISprintRepository>()
                .To<SprintRepository>()
                .InThreadScope();

            Bind<IUserRepository>()
                .To<UserRepository>()
                .InThreadScope();

            Bind<IExternalLoginRepository>()
                .To<ExternalLoginRepository>()
                .InThreadScope();
        }
    }
}