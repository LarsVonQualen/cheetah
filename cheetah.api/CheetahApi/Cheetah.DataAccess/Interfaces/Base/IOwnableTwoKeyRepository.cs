namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IOwnableTwoKeyRepository<TKey, TSecondaryKey, in TOwner, TValue> : 
        ITwoKeyRepository<TKey, TSecondaryKey, TValue>, 
        IOwner<TOwner, TValue> 
        where TValue : class, new()
    {

    }
}