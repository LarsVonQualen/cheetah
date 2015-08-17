using System;
using System.Collections.Generic;
using System.Linq;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;

namespace Cheetah.DataAccess.Repositories
{
    class TeamRepository :
        OwnableRepository<int, Guid, Team>,
        ITeamRepository
    {
        public ICollection<Team> GetByUserId(Guid userId)
        {
            using (var transaction = Database.GetTransaction())
            {
                var teamIds = Database.Fetch<TeamUserRelation>("WHERE UserId=@0", userId);

                var teams = teamIds.Select(relation => Get(relation.TeamId)).ToList();

                transaction.Complete();

                return teams;
            }
        }
    }
}