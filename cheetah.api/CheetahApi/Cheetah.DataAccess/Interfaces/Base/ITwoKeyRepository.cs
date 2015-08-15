using System.Reflection;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface ITwoKeyRepository<TKey, TSecondaryKey, TValue> :
        IRepository<TKey, TValue>
        where TValue : class, new()
    {
        string SecondaryKey { get; set; }
        PropertyInfo SecondaryKeyProperty { get; set; }

        void SetSecondaryKeyName(string secondaryKeyPropertyName);

        TSecondaryKey GetSecondaryKeyValue(TValue value);
        void SetSecondaryKeyValue(TValue obj, TSecondaryKey value);

        TValue Get(TSecondaryKey secondaryKey);
        void Delete(TSecondaryKey secondaryKey);
    }
}