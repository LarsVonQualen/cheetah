using System;
using System.Collections.Generic;
using System.Reflection;
using Cheetah.DataAccess.Interfaces.Base;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories.Base
{
    abstract class BaseRepository<TKey, TValue> : IBaseRepository<TKey, TValue> where TValue : class, new()
    {        
        public PetaPoco.Database Database { get; set; }

        public string PrimaryKey { get; set; }
        public PropertyInfo PrimaryKeyProperty { get; set; }
        
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
        }

        protected PropertyInfo GetPropertyInfo<TPropValue>(string propName)
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

        public virtual async System.Threading.Tasks.Task<TValue> GetAsync(TKey primaryKey)
        {
            return await new System.Threading.Tasks.Task<TValue>(() => Get(primaryKey));
        }

        public virtual async System.Threading.Tasks.Task<TValue> SaveAsync(TValue value)
        {
            return await new System.Threading.Tasks.Task<TValue>(() => Save(value));
        }

        public virtual async System.Threading.Tasks.Task DeleteAsync(TKey primaryKey)
        {
            await new System.Threading.Tasks.Task(() => Delete(primaryKey));
        }
    }
}