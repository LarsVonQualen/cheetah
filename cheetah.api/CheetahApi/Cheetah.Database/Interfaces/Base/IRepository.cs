namespace Cheetah.Database.Interfaces.Base
{
    public interface IRepository<TKey, TValue> where TValue : class, new()
    {
        TValue Get(TKey primaryKey);
        TValue Save(TValue value);
        void Delete(TKey primaryKey);
    }
}