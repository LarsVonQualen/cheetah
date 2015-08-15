using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;
using Task = System.Threading.Tasks.Task;

namespace Cheetah.DataAccess.Repositories
{
    class PasswordHashRepository :
        OwnableTwoKeyRepository<int, Guid, Guid, PasswordHash>,
        IPasswordHashRepository
    {
        public string FindPasswordHash(Guid userId)
        {
            var result = Get(userId);

            if (result == null)
                throw new ArgumentException("Invalid user id");

            return result.Hash;
        }

        public Task<string> FindPasswordHashAsync(Guid userId)
        {
            return new Task<string>(() => FindPasswordHash(userId));
        }

        public void SetPasswordHash(Guid userId, string hash)
        {
            var result = Get(userId);

            if (result == null)
                throw new ArgumentException("Invalid user id");

            result.Hash = hash;

            Save(result);
        }

        public Task SetPasswordHashAsync(Guid userId, string hash)
        {
            return new Task(() => SetPasswordHash(userId, hash));
        }
    }
}