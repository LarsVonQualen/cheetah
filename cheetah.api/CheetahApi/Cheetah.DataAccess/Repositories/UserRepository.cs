using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;
using Ninject;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories
{
    class UserRepository : 
        TwoKeyRepository<int, Guid, User>, 
        IUserRepository
    {
        [Inject]
        public UserProfileRepository UserProfileRepository { get; set; }

        public User Get(string username)
        {
            var result = Database.SingleOrDefault<User>("WHERE Username=@0", username);

            AfterGet(result);

            return result;
        }

        public ICollection<User> GetByTeam(int teamId)
        {
            using (var transaction = Database.GetTransaction())
            {
                var userIds = Database.Fetch<TeamUserRelation>("WHERE TeamId=@0", teamId);

                var users = userIds.Select(relation => Get(relation.UserId)).ToList();

                transaction.Complete();

                return users;
            }
        }

        public override void BeforeInsert(User value)
        {
            base.BeforeInsert(value);

            value.ClientId = Guid.NewGuid();
            value.UserId = Guid.NewGuid();

            if (value.UserProfile == null) return;

            var profile = UserProfileRepository.Save(value.UserProfile);

            value.UserProfileId = profile.Id;
        }

        public override void AfterGet(User value)
        {
            base.AfterGet(value);

            if (value.UserProfileId.HasValue)
                value.UserProfile = UserProfileRepository.Get(value.UserProfileId.GetValueOrDefault());
        }
    }
}