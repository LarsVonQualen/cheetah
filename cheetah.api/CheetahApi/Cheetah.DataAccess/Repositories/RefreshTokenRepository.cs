using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;
using PetaPoco;

namespace Cheetah.DataAccess.Repositories
{
    class RefreshTokenRepository :
        OwnableTwoKeyRepository<int, Guid, Guid, RefreshToken>,
        IRefreshTokenRepository
    {
        public RefreshToken Get(string token)
        {
            var result = Database.SingleOrDefault<RefreshToken>("WHERE Token=@0", token);

            AfterGet(result);

            return result;
        }
    }
}