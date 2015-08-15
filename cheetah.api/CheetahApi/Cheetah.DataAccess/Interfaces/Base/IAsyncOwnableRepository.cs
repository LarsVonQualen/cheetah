namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IAsyncOwnableRepository<TKey, in TOwner, TValue> : 
        IAsyncRepository<TKey, TValue>,
        IOwnerAsync<TOwner, TValue> 
        where TValue : class, new()
    {
         
    }
}