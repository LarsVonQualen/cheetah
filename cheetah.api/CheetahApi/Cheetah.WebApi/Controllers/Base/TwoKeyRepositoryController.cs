using System.Web.Http;
using Cheetah.DataAccess.Interfaces.Base;
using Ninject;

namespace Cheetah.WebApi.Controllers.Base
{
    public abstract class TwoKeyRepositoryController<TKey, TSecondaryKey, TValue, TRepository> : 
        RepositoryController<TKey, TValue, TRepository> 
        where TRepository : ITwoKeyRepository<TKey, TSecondaryKey, TValue>
        where TValue : class, new()
    {
        /// <summary>
        /// Gets a specific resource by the secondary key
        /// </summary>
        /// <param name="secondaryKey"></param>
        /// <returns></returns>
        [Route("{secondaryKey}")]
        [HttpGet]
        public virtual TValue Get(TSecondaryKey secondaryKey)
        {
            return Repository.Get(secondaryKey);
        }

        /// <summary>
        /// Deletes a specific resource by the secondary key
        /// </summary>
        /// <param name="secondaryKey"></param>
        [Route("{secondaryKey}")]
        [HttpDelete]
        public virtual void Delete(TSecondaryKey secondaryKey)
        {
            Repository.Delete(secondaryKey);
        }
    }
}