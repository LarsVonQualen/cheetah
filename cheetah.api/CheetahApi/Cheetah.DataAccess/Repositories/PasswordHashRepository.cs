using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;
using Ninject;
using PetaPoco;
using Task = System.Threading.Tasks.Task;

namespace Cheetah.DataAccess.Repositories
{
    class PasswordHashRepository :
        OwnableTwoKeyRepository<int, Guid, Guid, PasswordHash>,
        IPasswordHashRepository
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        public string FindPasswordHash(Guid userId)
        {
            var result = Get(userId);

            if (result == null)
                throw new ArgumentException("Invalid user id");

            return result.Hash;
        }

        public void SetPasswordHash(Guid userId, string hash)
        {
            var result = Get(userId) ?? new PasswordHash()
            {
                UserId = userId
            };

            result.Hash = hash;

            Save(result);
        }
    }
}