using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Interfaces
{
    public interface IUserRepository : IAsyncTwoKeyRepository<int, Guid, User>
    {
        User Get(string username);
        Task<User> GetAsync(string username);
    }
}