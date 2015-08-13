using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Repositories
{
    class TaskRepository : BaseRepository<int, Task, Guid>, ITaskRepository
    {
         
    }
}