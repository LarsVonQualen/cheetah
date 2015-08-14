using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Repositories
{
    class UserRepository : BaseRepository<Guid, User>, IUserRepository
    {
        public Task<User> GetByNameAsync(string userName)
        {
            return new Task<User>(() => GetByName(userName));
        }

        public User GetByName(string userName)
        {
            return Database.SingleOrDefault<User>("WHERE UserName=@0", userName);
        }

        public User GetByExternalLogin(string loginProvider, string providerKey)
        {
            var externalLogin = Database.SingleOrDefault<ExternalLogin>("WHERE LoginProvider=@0 AND ProviderKey=@1",
                loginProvider, providerKey);

            if (externalLogin == null)
                throw new ArgumentException("Invalid external login.");

            return Database.SingleOrDefault<User>(externalLogin.UserId);
        }

        public Task<User> GetByExternalLoginAsync(string loginProvider, string providerKey)
        {
            return new Task<User>(() => GetByExternalLogin(loginProvider, providerKey));
        }
    }
}