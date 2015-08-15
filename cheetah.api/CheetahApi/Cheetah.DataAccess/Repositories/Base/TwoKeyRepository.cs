using System.Reflection;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;

namespace Cheetah.DataAccess.Repositories.Base
{
    abstract class TwoKeyRepository<TKey, TSecondaryKey, TValue> :
        Repository<TKey, TValue>,
        IAsyncTwoKeyRepository<TKey, TSecondaryKey, TValue>
        where TValue : class, new()
    {
        protected TwoKeyRepository(string connectionString) : base(connectionString)
        {
            SetSecondaryKeyName("UserId");
        }

        protected TwoKeyRepository() : this("CheetahPocoModel")
        {
            
        }

        #region IAsyncTwoKeyRepository Implementation

        #region Convention Tools

        public string SecondaryKey { get; set; }
        public PropertyInfo SecondaryKeyProperty { get; set; }

        public void SetSecondaryKeyName(string secondaryKeyPropertyName)
        {
            SecondaryKey = secondaryKeyPropertyName;
            SecondaryKeyProperty = GetPropertyInfo<TValue>(secondaryKeyPropertyName);
        }

        public TSecondaryKey GetSecondaryKeyValue(TValue value)
        {
            return (TSecondaryKey)SecondaryKeyProperty.GetValue(value);
        }

        public void SetSecondaryKeyValue(TValue obj, TSecondaryKey value)
        {
            SecondaryKeyProperty.SetValue(obj, value);
        }

        #endregion

        public TValue Get(TSecondaryKey secondaryKey)
        {
            var result = Database.SingleOrDefault<TValue>($"WHERE {SecondaryKey}=@0", secondaryKey);

            AfterGet(result);

            return result;
        }

        public void Delete(TSecondaryKey secondaryKey)
        {
            var current = Get(secondaryKey);

            BeforeDelete(current);
            Database.Delete<TValue>($"WHERE {SecondaryKey}=@0", secondaryKey);
            AfterDelete(current);
        }

        public Task<TValue> GetAsync(TSecondaryKey secondaryKey)
        {
            return new Task<TValue>(() => Get(secondaryKey));
        }

        public Task DeleteAsync(TSecondaryKey secondaryKey)
        {
            return new Task(() => Delete(secondaryKey));
        }

        #endregion
    }
}