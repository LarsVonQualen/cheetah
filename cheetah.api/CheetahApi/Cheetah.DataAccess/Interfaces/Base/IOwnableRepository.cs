using System.Reflection;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IOwnableRepository<TKey, in TOwner, TValue> : 
        IRepository<TKey, TValue>, IOwner<TOwner, TValue> 
        where TValue : class, new()
    {
        string DefaultSortOrder { get; set; }
        void SetDefaultSortOrder(string propertyName, string order);
    }
}