using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace Cheetah.WebApi.Controllers.Base
{
    public abstract class BaseApiController<TKey, TValue> : ApiController
    {
        public virtual TValue Get()
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        public virtual TValue Get(TKey primaryKey)
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
        }

        public virtual TValue Post([FromBody] TValue value)
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        public virtual TValue Put([FromBody] TValue value)
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        public virtual void Delete(TKey primaryKey)
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.MethodNotAllowed);
        }
    }
}