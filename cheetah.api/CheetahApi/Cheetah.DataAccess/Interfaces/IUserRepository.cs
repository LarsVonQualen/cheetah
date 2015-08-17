using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Interfaces
{
    public interface IUserRepository : ITwoKeyRepository<int, Guid, User>
    {
        User Get(string username);
        ICollection<User> GetByTeam(int teamId);
    }
}