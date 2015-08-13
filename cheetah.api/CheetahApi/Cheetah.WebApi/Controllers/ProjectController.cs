using System.Web.Http;
using Cheetah.Database.Interfaces;
using Cheetah.WebApi.Controllers.Base;
using CheetahPocoModel;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("project")]
    public class ProjectController : BaseApiController<int, Project, IProjectRepository>
    {
        public ProjectController(IProjectRepository repository) : base(repository)
        {
        }

        public override Project Get()
        {
            throw new System.NotImplementedException();
        }

        public override Project Get(int primaryKey)
        {
            throw new System.NotImplementedException();
        }

        public override Project Post(Project value)
        {
            throw new System.NotImplementedException();
        }

        public override Project Put(Project value)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(int primaryKey)
        {
            throw new System.NotImplementedException();
        }
    }
}