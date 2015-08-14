using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Cheetah.DataAccess.Interfaces.Base
{
    public interface IOwner<TValue, TOWner> where TValue : class, new()
    {
        PropertyInfo OwnerProperty { get; set; }
        void SetOwnerPropertyName(string ownerPropertyName);
        ICollection<TValue> ListByOwner(TOWner ownerKey);
        Task<ICollection<TValue>> ListByOwnerAsync(TOWner ownerKey);
    }
}