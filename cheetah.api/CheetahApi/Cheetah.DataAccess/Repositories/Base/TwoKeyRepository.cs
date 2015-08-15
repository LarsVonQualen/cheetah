using System.Reflection;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories.Base
{
    abstract class TwoKeyRepository<TKey, TSecondaryKey, TValue> :
        Repository<TKey, TValue>,
        ITwoKeyRepository<TKey, TSecondaryKey, TValue>
        where TValue : class, new()
    {
        protected TwoKeyRepository() 
        {
            SetSecondaryKeyName("UserId");
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

        #endregion
    }
}