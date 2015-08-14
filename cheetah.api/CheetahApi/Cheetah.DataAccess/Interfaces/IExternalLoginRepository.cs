using System;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Interfaces
{
    public interface IExternalLoginRepository : IOwnableRepository<Guid, ExternalLogin, Guid>
    {
        void DeleteByOwnerAndProvider(Guid userId, string loginProvider);
        System.Threading.Tasks.Task DeleteByOwnerAndProviderAsync(Guid userId, string loginProvider);
    }
}