using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Interfaces
{
    public interface IUserRepository : IBaseRepository<Guid, User>
    {
        Task<User> GetByNameAsync(string userName);
        User GetByName(string userName);
        User GetByExternalLogin(string loginProvider, string providerKey);
        Task<User> GetByExternalLoginAsync(string loginProvider, string providerKey);
    }
}