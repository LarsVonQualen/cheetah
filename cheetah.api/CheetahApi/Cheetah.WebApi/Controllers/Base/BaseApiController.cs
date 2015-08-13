using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace Cheetah.WebApi.Controllers.Base
{
    public abstract class BaseApiController<TKey, TValue, TRepository> : ApiController
    {
        public TRepository Repository { get; set; }

        protected BaseApiController(
            TRepository repository
            )
        {
            Repository = repository;
        }

        public abstract TValue Get();
        public abstract TValue Get(TKey primaryKey);
        public abstract TValue Post([FromBody] TValue value);
        public abstract TValue Put([FromBody] TValue value);
        public abstract void Delete(TKey primaryKey);
    }
}