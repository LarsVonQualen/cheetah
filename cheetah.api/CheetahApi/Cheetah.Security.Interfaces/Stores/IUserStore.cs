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
    }
}