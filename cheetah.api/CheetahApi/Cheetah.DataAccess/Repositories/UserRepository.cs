using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;

namespace Cheetah.DataAccess.Repositories
{
    class UserRepository : 
        TwoKeyRepository<int, Guid, User>, 
        IUserRepository
    {
        public User Get(string username)
        {
            var result = Database.SingleOrDefault<User>("WHERE Username=@0", username);

            AfterGet(result);

            return result;
        }

        public Task<User> GetAsync(string username)
        {
            return new Task<User>(() => Get(username));
        }
    }
}