using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Interfaces
{
    public interface IBillingAddressRepository :
        IOwnableRepository<int, int, BillingAddress>
    {
         
    }
}