using System;
using System.Collections.Generic;
using System.Reflection;
using Cheetah.DataAccess.Interfaces.Base;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories.Base
{
    abstract class BaseRepository<TKey, TValue, TOwner> : IBaseRepository<TKey, TValue, TOwner> where TValue : class, new()
    {        
        public PetaPoco.Database Database { get; set; }

        public string PrimaryKey { get; set; }
        public PropertyInfo PrimaryKeyProperty { get; set; }
        public PropertyInfo OwnerProperty { get; set; }
        public PropertyInfo CreatedAtProperty { get; set; }
        public PropertyInfo LastUpdatedAtProperty { get; set; }

        #region Property - DefaultSortOrder

        private string _internalDefaultSortOrder;

        public string DefaultSortOrder
        {
            get
            {
                if (!string.IsNullOrEmpty(_internalDefaultSortOrder))
                    return _internalDefaultSortOrder;

                var prop = CreatedAtProperty ?? PrimaryKeyProperty;

                return $"ORDER BY {prop.Name} DESC";
            }

            set { _internalDefaultSortOrder = value; }
        }

        #endregion

        protected BaseRepository()
        {
            Database = new PetaPoco.Database("CheetahPocoModel");

            var primaryKey = typeof (TValue).GetCustomAttribute<PrimaryKeyAttribute>();
            PrimaryKey = primaryKey.Value;
            SetPrimaryKeyName(PrimaryKey);

            SetLastUpdatedAtPropertyName("LastUpdatedAt");
            SetCreatedAtPropertyName("CreatedAt");
            SetOwnerPropertyName("CreatedBy");
        }

        private PropertyInfo GetPropertyInfo<TPropValue>(string propName)
        {
            return typeof (TPropValue).GetProperty(propName);
        }

        protected void SetPrimaryKeyName(string primaryKeyPropertyName)
        {
            PrimaryKeyProperty = GetPropertyInfo<TValue>(primaryKeyPropertyName);
        }

        protected void SetLastUpdatedAtPropertyName(string lastUpdatedAtPropertyName)
        {
            LastUpdatedAtProperty = GetPropertyInfo<TValue>(lastUpdatedAtPropertyName);
        }

        protected void SetCreatedAtPropertyName(string createdAtPropertyName)
        {
            CreatedAtProperty = GetPropertyInfo<TValue>(createdAtPropertyName);
        }

        protected void SetOwnerPropertyName(string ownerPropertyName)
        {
            OwnerProperty = GetPropertyInfo<TValue>(ownerPropertyName);
        }

        public virtual TValue Get(TKey primaryKey)
        {
            return Database.SingleOrDefault<TValue>(primaryKey);
        }

        public virtual TValue Save(TValue value)
        {
            using (var transaction = Database.GetTransaction())
            {
                if (Database.IsNew(value))
                {
                    BeforeInsert(value);
                    Database.Insert(value);
                    AfterInsert(value);                    
                }
                else
                {
                    var current = Get((TKey) PrimaryKeyProperty.GetValue(value));

                    BeforeUpdate(current, value);
                    Database.Update(value);
                    AfterUpdate(current, value);
                }

                transaction.Complete();
            }

            return value;
        }

        public virtual void Delete(TKey primaryKey)
        {
            using (var transaction = Database.GetTransaction())
            {
                var current = Get(primaryKey);

                BeforeDelete(current);
                Database.Delete<TValue>(primaryKey);
                AfterDelete(current);

                transaction.Complete();
            }
        }

        public virtual ICollection<TValue> ListByOwner(TOwner ownerKey)
        {
            if (OwnerProperty == null)
                throw new Exception(
                    $"The repository '{this.GetType().Name}' does not have access to valid properties for the Owner interface");

            return Database.Fetch<TValue>($"WHERE {OwnerProperty.Name}=@0 {DefaultSortOrder}", ownerKey);
        }

        protected virtual void BeforeUpdate(TValue oldValue, TValue newValue)
        {
            LastUpdatedAtProperty.SetValue(newValue, DateTime.UtcNow);
        }

        protected virtual void AfterUpdate(TValue oldValue, TValue newValue)
        {

        }

        protected virtual void BeforeInsert(TValue value)
        {
            var now = DateTime.UtcNow;

            CreatedAtProperty.SetValue(value, now);
            LastUpdatedAtProperty.SetValue(value, now);
        }

        protected virtual void AfterInsert(TValue newValue)
        {

        }

        protected virtual void BeforeDelete(TValue value)
        {

        }

        protected virtual void AfterDelete(TValue value)
        {

        }
    }
}