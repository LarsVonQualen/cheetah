using System;
using Cheetah.Database.Interfaces.Base;
using CheetahPocoModel;

namespace Cheetah.Database.Interfaces
{
    public interface IProjectRepository : IBaseRepository<int, Project, Guid>
    {
         
    }
}