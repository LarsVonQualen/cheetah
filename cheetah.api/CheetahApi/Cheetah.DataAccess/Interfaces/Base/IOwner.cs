using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IOwner<in TOwner, TValue> 
        where TValue : class, new()
    {
        string OwnerKeyName { get; set; }
        PropertyInfo OwnerProperty { get; set; }
        void SetOwnerPropertyName(string ownerPropertyName);
        ICollection<TValue> ListByOwner(TOwner ownerKey);
    }
}