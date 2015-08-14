using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Microsoft.AspNet.Identity;
using Task = System.Threading.Tasks.Task;

namespace Cheetah.WebApi.Identity
{
    public class PetaPocoUserStore : IPetaPocoUserStore
    {
        private readonly IUserRepository _userRepository;
        private readonly IExternalLoginRepository _externalLoginRepository;

        public PetaPocoUserStore(
            IUserRepository userRepository,
            IExternalLoginRepository externalLoginRepository
            )
        {
            _userRepository = userRepository;
            _externalLoginRepository = externalLoginRepository;
        }

        public void Dispose()
        {
            
        }

        public Task CreateAsync(User user)
        {
            return _userRepository.SaveAsync(user);
        }

        public Task UpdateAsync(User user)
        {
            return _userRepository.SaveAsync(user);
        }

        public Task DeleteAsync(User user)
        {
            return _userRepository.DeleteAsync(user.UserId);
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return _userRepository.GetAsync(Guid.Parse(userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return _userRepository.GetByNameAsync(userName);
        }

        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            return _externalLoginRepository.SaveAsync(new ExternalLogin()
            {
                UserId = user.UserId,
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            });
        }

        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            return _externalLoginRepository.DeleteByOwnerAndProviderAsync(user.UserId, login.LoginProvider);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {            
            return new Task<IList<UserLoginInfo>>(() =>
            {
                var externalLogins = _externalLoginRepository.ListByOwner(user.UserId);
                return
                    externalLogins.ToList()
                        .Select(login => new UserLoginInfo(login.LoginProvider, login.ProviderKey))
                        .ToList();
            });
        }

        public Task<User> FindAsync(UserLoginInfo login)
        {
            return _userRepository.GetByExternalLoginAsync(login.LoginProvider, login.ProviderKey);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;

            return _userRepository.SaveAsync(user);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return new Task<string>(() => _userRepository.Get(user.UserId).PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return new Task<bool>(() => string.IsNullOrEmpty(_userRepository.Get(user.UserId).PasswordHash));
        }

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            user.SecurityStamp = stamp;

            return _userRepository.SaveAsync(user);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            return new Task<string>(() => _userRepository.Get(user.UserId).SecurityStamp);
        }
    }
}