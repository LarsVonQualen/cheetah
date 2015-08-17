using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories.Base
{
    abstract class OwnableTwoKeyRepository<TKey, TSecondaryKey, TOwner, TValue> :
        TwoKeyRepository<TKey, TSecondaryKey, TValue>,        
        IOwnableTwoKeyRepository<TKey, TSecondaryKey, TOwner, TValue>
        where TValue : class, new()
    {
        protected OwnableTwoKeyRepository()
        {
            SetOwnerPropertyName("CreatedBy");
            SetDefaultSortOrder(CreatedAtProperty.Name, "DESC");
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
            return Database.Fetch<TValue>($"WHERE {OwnerKeyName}=@0 {DefaultSortOrder}", ownerKey);
        }

        #endregion
    }
}