using System.Reflection;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IRepository<TKey, TValue> 
        where TValue : class, new()
    {
        PetaPoco.Database Database { get; set; }
        string PrimaryKey { get; set; }
        PropertyInfo PrimaryKeyProperty { get; set; }
        PropertyInfo CreatedAtProperty { get; set; }
        PropertyInfo LastUpdatedAtProperty { get; set; }

        PropertyInfo GetPropertyInfo<TPropValue>(string propName);        

        void SetPrimaryKeyName(string primaryKeyPropertyName);
        void SetLastUpdatedAtPropertyName(string lastUpdatedAtPropertyName);
        void SetCreatedAtPropertyName(string createdAtPropertyName);

        TKey GetPrimaryKeyValue(TValue value);
        void SetPrimaryKeyValue(TValue obj, TKey value);

        void SetCreatedAtValue(TValue obj, object value);
        void SetLastUpdatedAtValue(TValue obj, object value);

        TValue Get(TKey primaryKey);
        TValue Save(TValue value);
        void Delete(TKey primaryKey);

        void AfterGet(TValue value);
        void BeforeInsert(TValue value);
        void AfterInsert(TValue newValue);
        void BeforeUpdate(TValue oldValue, TValue newValue);
        void AfterUpdate(TValue oldValue, TValue newValue);
        void BeforeDelete(TValue value);
        void AfterDelete(TValue value);
    }
}