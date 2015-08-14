namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IBaseRepository<TKey, TValue> : IRepository<TKey, TValue>, IAsyncRepository<TKey, TValue> where TValue : class, new ()
    {
         
    }
}