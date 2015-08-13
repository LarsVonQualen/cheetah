using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Repositories
{
    class UserstoryRepository : BaseRepository<int, Userstory, Guid>, IUserstoryRepository
    {
         
    }
}