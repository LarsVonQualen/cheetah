using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Repositories
{
    class TeamRepository : BaseRepository<int, Team, Guid>, ITeamRepository
    {
         
    }
}