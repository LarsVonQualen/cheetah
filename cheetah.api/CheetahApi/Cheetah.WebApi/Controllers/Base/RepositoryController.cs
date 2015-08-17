using System.Web.Http;
using Cheetah.DataAccess.Interfaces.Base;
using Ninject;

namespace Cheetah.WebApi.Controllers.Base
{
    public abstract class RepositoryController<TKey, TValue, TRepository> : BaseController
        where TRepository : IRepository<TKey, TValue>
        where TValue : class, new()
    {
        [Inject]
        public TRepository Repository { get; set; }

        /// <summary>
        /// Gets a specific resource by the primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        [Route("{primaryKey}")]
        [HttpGet]
        public virtual TValue Get(TKey primaryKey)
        {
            return Repository.Get(primaryKey);
        }

        /// <summary>
        /// Posts a new resource
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public virtual TValue Post([FromBody] TValue value)
        {
            return Repository.Save(value);
        }

        /// <summary>
        /// Updates a resource
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPut]
        public virtual TValue Put([FromBody] TValue value)
        {
            return Repository.Save(value);
        }

        /// <summary>
        /// Deletes a specific resource by the primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        [Route("{primaryKey}")]
        [HttpDelete]
        public virtual void Delete(TKey primaryKey)
        {
            Repository.Delete(primaryKey);
        }
    }
}