namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IAsyncOwnableTwoKeyRepository<TKey, TSecondaryKey, in TOwner, TValue> :
        IAsyncTwoKeyRepository<TKey, TSecondaryKey, TValue>,
        IOwnerAsync<TOwner, TValue> 
        where TValue : class, new()
    {
         
    }
}