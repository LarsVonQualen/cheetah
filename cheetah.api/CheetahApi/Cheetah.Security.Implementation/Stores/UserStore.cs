using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Interfaces.Stores;
using Task = System.Threading.Tasks.Task;

namespace Cheetah.Security.Implementation.Stores
{
    class UserStore : IUserStore<User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashRepository _passwordHashRepository;

        public UserStore(
            IUserRepository userRepository,
            IPasswordHashRepository passwordHashRepository
            )
        {
            _userRepository = userRepository;
            _passwordHashRepository = passwordHashRepository;
        }

        public User Find(Guid userId)
        {
            return _userRepository.Get(userId);
        }

        public User Find(string username)
        {
            return _userRepository.Get(username);
        }

        public User Create(User newUser)
        {
            return _userRepository.Save(newUser);
        }

        public string FindPasswordHash(Guid userId)
        {
            return _passwordHashRepository.FindPasswordHash(userId);
        }

        public void SetPasswordHash(Guid userId, string hash)
        {
            _passwordHashRepository.SetPasswordHashAsync(userId, hash);
        }

        public Task<User> FindAsync(Guid userId)
        {
            return _userRepository.GetAsync(userId);
        }

        public Task<User> FindAsync(string username)
        {
            return _userRepository.GetAsync(username);
        }

        public Task<User> CreateAsync(User newUser)
        {
            return _userRepository.SaveAsync(newUser);
        }

        public Task<string> FindPasswordHashAsync(Guid userId)
        {
            return _passwordHashRepository.FindPasswordHashAsync(userId);
        }

        public Task SetPasswordHashAsync(Guid userId, string hash)
        {
            return _passwordHashRepository.SetPasswordHashAsync(userId, hash);
        }
    }
}