using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Repositories.Base;
using Cheetah.DataAccess.Models;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories
{
    abstract class OwnableRepository<TKey, TOwner, TValue> : 
        Repository<TKey, TValue>,
        IOwnableRepository<TKey, TOwner, TValue> 
        where TValue : class, new()
    {
        protected OwnableRepository()
        {
            SetOwnerPropertyName("CreatedBy");
            SetDefaultSortOrder(CreatedAtProperty.Name, "DESC");
        }

        #region IAsyncOwnableRepository implementation

        #region Convention Tools

        public string OwnerKeyName { get; set; }
        public PropertyInfo OwnerProperty { get; set; }
        public string DefaultSortOrder { get; set; }

        public void SetOwnerPropertyName(string ownerPropertyName)
        {
            OwnerKeyName = ownerPropertyName;
            OwnerProperty = GetPropertyInfo<TValue>(ownerPropertyName);
        }

        public void SetDefaultSortOrder(string propertyName, string order)
        {
            DefaultSortOrder = $"ORDER BY {propertyName} {order}";
        }

        #endregion

        public ICollection<TValue> ListByOwner(TOwner ownerKey)
        {
            return Database.Fetch<TValue>($"WHERE {OwnerKeyName}=@0 {DefaultSortOrder}", ownerKey);
        }

        #endregion        
    }
}