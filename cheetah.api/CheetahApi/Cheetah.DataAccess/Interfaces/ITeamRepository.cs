using System;
using System.Collections.Generic;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Interfaces
{
    public interface ITeamRepository :
        IOwnableRepository<int, Guid, Team>
    {
        ICollection<Team> GetByUserId(Guid userId);
    }
}