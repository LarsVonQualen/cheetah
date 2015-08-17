using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;

namespace Cheetah.DataAccess.Repositories
{
    class BillingAddressRepository :
        OwnableRepository<int, int, BillingAddress>,
        IBillingAddressRepository
    {
        public BillingAddressRepository()
        {
            SetOwnerPropertyName("CorporationId");
        }
    }
}