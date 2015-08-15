﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Repositories.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Repositories
{
    abstract class OwnableRepository<TKey, TOwner, TValue> : 
        Repository<TKey, TValue>,
        IAsyncOwnableRepository<TKey, TOwner, TValue> 
        where TValue : class, new()
    {
        protected OwnableRepository(string connectionString) : base(connectionString)
        {
            SetOwnerPropertyName("CreatedBy");
        }

        protected OwnableRepository() : this("CheetahPocoModel")
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