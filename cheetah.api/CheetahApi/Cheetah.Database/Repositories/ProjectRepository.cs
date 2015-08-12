using System;
using Cheetah.Database.Interfaces;
using Cheetah.Database.Repositories.Base;
using CheetahPocoModel;

namespace Cheetah.Database.Repositories
{
    class ProjectRepository : BaseRepository<int, Project, Guid>, IProjectRepository
    {
         
    }
}