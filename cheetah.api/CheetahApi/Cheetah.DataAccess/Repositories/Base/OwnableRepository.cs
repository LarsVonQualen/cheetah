using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Repositories.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Repositories
{
    abstract class OwnableRepository<TKey, TValue, TOwner> : BaseRepository<TKey, TValue>, IOwnableRepository<TKey, TValue, TOwner> where TValue : class, new()
    {
        protected OwnableRepository() : base()
        {
            SetOwnerPropertyName("CreatedBy");
        }

        public PropertyInfo OwnerProperty { get; set; }
        public void SetOwnerPropertyName(string ownerPropertyName)
        {
            OwnerProperty = GetPropertyInfo<TValue>(ownerPropertyName);
        }

        public virtual ICollection<TValue> ListByOwner(TOwner ownerKey)
        {
            if (OwnerProperty == null)
                throw new Exception(
                    $"The repository '{this.GetType().Name}' does not have access to valid properties for the Owner interface");

            return Database.Fetch<TValue>($"WHERE {OwnerProperty.Name}=@0 {DefaultSortOrder}", ownerKey);
        }

        public async Task<ICollection<TValue>> ListByOwnerAsync(TOwner ownerKey)
        {
            return await new Task<ICollection<TValue>>(() => ListByOwner(ownerKey));
        }
    }
}