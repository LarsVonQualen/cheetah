using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Models;
using Task = System.Threading.Tasks.Task;

namespace Cheetah.DataAccess.Interfaces
{
    public interface IPasswordHashRepository :
        IOwnableTwoKeyRepository<int, Guid, Guid, PasswordHash>
    {
        string FindPasswordHash(Guid userId);
        void SetPasswordHash(Guid userId, string hash);
    }
}