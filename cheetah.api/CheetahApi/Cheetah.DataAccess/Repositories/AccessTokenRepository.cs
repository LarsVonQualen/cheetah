using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories
{
    class AccessTokenRepository :
        OwnableTwoKeyRepository<int, Guid, Guid, AccessToken>,
        IAccessTokenRepository
    {
        public AccessToken Get(string token)
        {
            var result = Database.SingleOrDefault<AccessToken>("WHERE Token=@0", token);

            AfterGet(result);

            return result;
        }
    }
}