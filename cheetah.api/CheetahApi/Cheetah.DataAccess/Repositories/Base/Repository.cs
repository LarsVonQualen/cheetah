using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces.Base;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories.Base
{
    abstract class Repository<TKey, TValue> : IAsyncRepository<TKey, TValue> where TValue : class, new()
    {
        #region Constructors

        protected Repository(string connectionString)
        {
            Database = new Database(connectionString);

            var primaryKey = typeof(TValue).GetCustomAttribute<PrimaryKeyAttribute>();
            PrimaryKey = primaryKey.Value;
            SetPrimaryKeyName(PrimaryKey);

            SetLastUpdatedAtPropertyName("LastUpdatedAt");
            SetCreatedAtPropertyName("CreatedAt");
        }

        protected Repository() : this("CheetahPocoModel")
        {

        }

        #endregion

        #region IRepository Implementation

        #region Properties

        public Database Database { get; set; }
        public string PrimaryKey { get; set; }
        public PropertyInfo PrimaryKeyProperty { get; set; }
        public PropertyInfo CreatedAtProperty { get; set; }
        public PropertyInfo LastUpdatedAtProperty { get; set; }

        #endregion

        #region ConventionTools

        public PropertyInfo GetPropertyInfo<TPropValue>(string propName)
        {
            return typeof(TPropValue).GetProperty(propName);
        }

        public void SetPrimaryKeyName(string primaryKeyPropertyName)
        {
            PrimaryKeyProperty = GetPropertyInfo<TValue>(primaryKeyPropertyName);
        }

        public void SetLastUpdatedAtPropertyName(string lastUpdatedAtPropertyName)
        {
            LastUpdatedAtProperty = GetPropertyInfo<TValue>(lastUpdatedAtPropertyName);
        }

        public void SetCreatedAtPropertyName(string createdAtPropertyName)
        {
            CreatedAtProperty = GetPropertyInfo<TValue>(createdAtPropertyName);
        }

        public TKey GetPrimaryKeyValue(TValue value)
        {
            return (TKey)PrimaryKeyProperty.GetValue(value);
        }

        public void SetPrimaryKeyValue(TValue obj, TKey value)
        {
            PrimaryKeyProperty.SetValue(obj, value);
        }

        public void SetCreatedAtValue(TValue obj, object value)
        {
            CreatedAtProperty.SetValue(obj, value);
        }

        public void SetLastUpdatedAtValue(TValue obj, object value)
        {
            LastUpdatedAtProperty.SetValue(obj, value);
        }

        #endregion

        public virtual TValue Get(TKey primaryKey)
        {
            var result = Database.SingleOrDefault<TValue>(primaryKey);

            AfterGet(result);

            return result;
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
                    var current = Get(GetPrimaryKeyValue(value));

                    BeforeUpdate(current, value);
                    Database.Update(value);
                    AfterUpdate(current, value);
                }

                transaction.Complete();

                return value;
            }
        }

        public virtual void Delete(TKey primaryKey)
        {
            var current = Get(primaryKey);

            BeforeDelete(current);
            Database.Delete<TValue>(primaryKey);
            AfterDelete(current);
        }

        public virtual void AfterGet(TValue value)
        {
            
        }

        public virtual void BeforeInsert(TValue value)
        {
            
        }

        public virtual void AfterInsert(TValue newValue)
        {
            
        }

        public virtual void BeforeUpdate(TValue oldValue, TValue newValue)
        {
            SetLastUpdatedAtValue(newValue, DateTime.UtcNow);
        }

        public virtual void AfterUpdate(TValue oldValue, TValue newValue)
        {
            
        }

        public virtual void BeforeDelete(TValue value)
        {
            
        }

        public virtual void AfterDelete(TValue value)
        {
            
        }

        #endregion

        #region IAsyncRepository Implementation

        public virtual Task<TValue> GetAsync(TKey primaryKey)
        {
            return new Task<TValue>(() => Get(primaryKey));
        }

        public virtual Task<TValue> SaveAsync(TValue value)
        {
            return new Task<TValue>(() => Save(value));
        }

        public virtual Task DeleteAsync(TKey primaryKey)
        {
            return new Task(() => Delete(primaryKey));
        }

        #endregion
    }
}