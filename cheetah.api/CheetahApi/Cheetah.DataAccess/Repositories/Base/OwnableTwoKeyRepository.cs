using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;

namespace Cheetah.DataAccess.Repositories.Base
{
    abstract class OwnableTwoKeyRepository<TKey, TSecondaryKey, TOwner, TValue> :
        TwoKeyRepository<TKey, TSecondaryKey, TValue>,        
        IAsyncOwnableTwoKeyRepository<TKey, TSecondaryKey, TOwner, TValue>
        where TValue : class, new()
    {
        protected OwnableTwoKeyRepository(string connectionString) : base(connectionString)
        {
            SetOwnerPropertyName("CreatedBy");
        }

        protected OwnableTwoKeyRepository() : this("CheetahPocoModel")
        {

        }

        #region IAsyncOwnableRepository implementation

        #region Convention Tools

        public string OwnerKeyName { get; set; }
        public PropertyInfo OwnerProperty { get; set; }

        public void SetOwnerPropertyName(string ownerPropertyName)
        {
            OwnerKeyName = ownerPropertyName;
            OwnerProperty = GetPropertyInfo<TValue>(ownerPropertyName);
        }

        #endregion

        public ICollection<TValue> ListByOwner(TOwner ownerKey)
        {
            return Database.Fetch<TValue>($"WHERE {OwnerKeyName}=@0", ownerKey);
        }

        public Task<ICollection<TValue>> ListByOwnerAsync(TOwner ownerKey)
        {
            return new Task<ICollection<TValue>>(() => ListByOwner(ownerKey));
        }

        #endregion
    }
}