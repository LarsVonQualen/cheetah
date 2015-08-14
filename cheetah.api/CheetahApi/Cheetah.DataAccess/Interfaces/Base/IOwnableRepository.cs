using System.Reflection;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IOwnableRepository<TKey, TValue, TOwner> : IBaseRepository<TKey, TValue>, IOwner<TValue, TOwner> where TValue : class, new()
    {
        
    }
}