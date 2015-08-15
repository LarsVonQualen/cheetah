using System.Threading.Tasks;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IAsyncRepository<TKey, TValue> :
        IRepository<TKey, TValue> 
        where TValue : class, new()
    {
        Task<TValue> GetAsync(TKey primaryKey);
        Task<TValue> SaveAsync(TValue value);
        Task DeleteAsync(TKey primaryKey);
    }
}