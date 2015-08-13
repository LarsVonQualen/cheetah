using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Repositories
{
    class SprintRetrospectiveRepository : BaseRepository<int, SprintRetrospective, Guid>, ISprintRetrospectiveRepository
    {
         
    }
}