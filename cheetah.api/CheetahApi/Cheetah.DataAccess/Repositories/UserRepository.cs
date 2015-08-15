using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;
using PetaPoco;

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

        public override void BeforeInsert(User value)
        {
            base.BeforeInsert(value);

            value.ClientId = Guid.NewGuid();
            value.UserId = Guid.NewGuid();
        }
    }
}