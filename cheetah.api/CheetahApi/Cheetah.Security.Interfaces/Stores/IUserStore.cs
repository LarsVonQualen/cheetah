using System;
using System.Threading.Tasks;
using Cheetah.Security.Interfaces.Models;

namespace Cheetah.Security.Interfaces.Stores
{
    public interface IUserStore<TUser> where TUser : IUser
    {
        TUser Find(Guid userId);
        TUser Find(string username);
        TUser Create(TUser newUser);
        string FindPasswordHash(Guid userId);
        void SetPasswordHash(Guid userId, string hash);

        Task<TUser> FindAsync(Guid userId);
        Task<TUser> FindAsync(string username);
        Task<TUser> CreateAsync(TUser newUser);
        Task<string> FindPasswordHashAsync(Guid userId);
        Task SetPasswordHashAsync(Guid userId, string hash);
    }
}