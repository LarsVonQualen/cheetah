using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.DataAccess.Interfaces
{
    public interface ITokenRepository<TValue> :
        IAsyncOwnableTwoKeyRepository<int, Guid, Guid, TValue>
        where TValue : class, new()
    {
        TValue Get(string token);
        Task<TValue> GetAsync(string token);
    }
}