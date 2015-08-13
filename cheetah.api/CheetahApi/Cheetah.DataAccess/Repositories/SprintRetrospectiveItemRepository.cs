using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Repositories
{
    class SprintRetrospectiveItemRepository : BaseRepository<int, SprintRetrospectiveItem, Guid>, ISprintRetrospectiveItemRepository
    {
         
    }
}