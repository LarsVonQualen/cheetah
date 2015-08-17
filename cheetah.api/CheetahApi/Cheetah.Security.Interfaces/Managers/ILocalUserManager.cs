using Cheetah.Security.Interfaces.Models;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Interfaces.Managers
{
    public interface ILocalUserManager<TUser, TAccessToken, TRefreshToken> : IUserManager<TUser, TAccessToken, TRefreshToken, ILocalAuthRequest>
        where TUser : IUser
        where TAccessToken : IExpirableToken
        where TRefreshToken : IToken
    {
         
    }
}