using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IOwnerAsync<in TOwner, TValue> : 
        IOwner<TOwner, TValue>
        where TValue : class,new()
    {
        Task<ICollection<TValue>> ListByOwnerAsync(TOwner ownerKey);
    }
}