using System;
using Cheetah.DataAccess.Interfaces.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Interfaces
{
    public interface ISprintRepository : IBaseRepository<int, Sprint, Guid>
    {

    }
}