using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.DataAccess.Repositories.Base;

namespace Cheetah.DataAccess.Repositories
{
    class UserProfileRepository : 
        Repository<int, UserProfile>,
        IUserProfileRepository
    {
         
    }
}