namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IBaseRepository<TKey, TValue, TOwner> : IRepository<TKey, TValue>, IOwner<TValue, TOwner> where TValue : class, new ()
    {
         
    }
}