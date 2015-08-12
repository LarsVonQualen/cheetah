using System.Collections.Generic;

namespace Cheetah.Database.Interfaces.Base
{
    public interface IOwner<TValue, TOWner> where TValue : class, new()
    {
        ICollection<TValue> ListByOwner(TOWner ownerKey);
    }
}