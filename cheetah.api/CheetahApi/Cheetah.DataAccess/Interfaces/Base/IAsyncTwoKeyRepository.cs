using System.Threading.Tasks;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IAsyncTwoKeyRepository<TKey, TSecondaryKey, TValue> :
        ITwoKeyRepository<TKey, TSecondaryKey, TValue>
        where TValue : class, new()
    {
        Task<TValue> GetAsync(TSecondaryKey secondaryKey);
        Task<TValue> SaveAsync(TValue value);
        Task DeleteAsync(TSecondaryKey secondaryKey);
    }
}