using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Repositories
{
    class ExternalLoginRepository : OwnableRepository<Guid, ExternalLogin, Guid>, IExternalLoginRepository
    {
        private readonly IUserRepository _userRepository;

        public ExternalLoginRepository(
            IUserRepository userRepository
            ) : base()
        {
            _userRepository = userRepository;

            SetOwnerPropertyName("UserId");
        }

        public override ExternalLogin Get(Guid primaryKey)
        {
            var result = base.Get(primaryKey);

            if (result != null)
            {
                result.User = _userRepository.Get(result.UserId);
            }

            return result;
        }

        public override Task<ExternalLogin> GetAsync(Guid primaryKey)
        {
            return new Task<ExternalLogin>(() => Get(primaryKey));
        }

        

        public void DeleteByOwnerAndProvider(Guid userId, string loginProvider)
        {
            Database.Delete<ExternalLogin>("WHERE UserId=@0 AND LoginProvider=@1", userId, loginProvider);
        }

        public System.Threading.Tasks.Task DeleteByOwnerAndProviderAsync(Guid userId, string loginProvider)
        {
            return new System.Threading.Tasks.Task(() => DeleteByOwnerAndProvider(userId, loginProvider));
        }
    }
}