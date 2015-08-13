using System;
using Cheetah.DataAccess.Interfaces.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Interfaces
{
    public interface ITaskRepository : IBaseRepository<int, Task, Guid>
    {

    }
}