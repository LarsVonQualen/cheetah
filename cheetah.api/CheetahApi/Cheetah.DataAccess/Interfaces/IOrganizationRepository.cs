using System;
using Cheetah.DataAccess.Interfaces.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Interfaces
{
    public interface IOrganizationRepository : IBaseRepository<int, Organization, Guid>
    {

    }
}