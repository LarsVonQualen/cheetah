using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.DataAccess.Interfaces
{
    public interface ITokenRepository<TValue> :
        IOwnableTwoKeyRepository<int, Guid, Guid, TValue>
        where TValue : class, new()
    {
        TValue Get(string token);
    }
}