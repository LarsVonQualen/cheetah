using System.Threading.Tasks;
using Cheetah.Security.Interfaces.Models;
using Cheetah.Security.Interfaces.Models.Base;
using Cheetah.Security.Interfaces.Stores;
using Cheetah.Security.Interfaces.Utils;

namespace Cheetah.Security.Interfaces.Managers
{
    public interface IUserManager<TUser, TAccessToken, TRefreshToken, in TTAuthRequest> 
        where TUser : IUser 
        where TAccessToken : IExpirableToken 
        where TRefreshToken : IToken
        where TTAuthRequest : IAuthRequest
    {
        ITokenStore<TAccessToken> AccessTokenStore { get; set; }
        ITokenStore<TRefreshToken> RefreshTokenStore { get; set; }  
        IUserStore<TUser> UserStore { get; set; }
        IHasher Hasher { get; set; }
        IPasswordHasher PasswordHasher { get; set; }
        ITokenGenerator TokenGenerator { get; set; }

        TRefreshToken Create(TUser user, string password);
        IAuthorizationGrant Authorize(TTAuthRequest authRequest);
        TAccessToken Refresh(IRefreshRequest<TRefreshToken> refreshRequest);
        IAuthenticationResponse Authenticate(string accessToken);

        Task<TRefreshToken> CreateAsync(TUser user, string password);
        Task<IAuthorizationGrant> AuthorizeAsync(TTAuthRequest authRequest);
        Task<TAccessToken> RefreshAsync(IRefreshRequest<TRefreshToken> refreshRequest);
        Task<IAuthenticationResponse> AuthenticateAsync(string accessToken);
    }
}