namespace Cheetah.WebApi.Controllers.Base
{
    public abstract class RepoController<TKey, TValue, TRepository> : BaseApiController<TKey, TValue>
    {
        public TRepository Repository { get; set; }

        protected RepoController(
            TRepository repository
            ) : base()
        {
            Repository = repository;
        }
    }
}