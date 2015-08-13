using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Repositories
{
    class ProjectRepository : BaseRepository<int, Project, Guid>, IProjectRepository
    {
         
    }
}