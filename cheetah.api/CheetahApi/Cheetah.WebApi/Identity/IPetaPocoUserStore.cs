using Cheetah.DataAccess.Models;
using Microsoft.AspNet.Identity;

namespace Cheetah.WebApi.Identity
{
    public interface IPetaPocoUserStore : IUserStore<User>, IUserLoginStore<User>, IUserPasswordStore<User>, IUserSecurityStampStore<User>, IUserTokenProvider<User, string>
    {
         
    }
}