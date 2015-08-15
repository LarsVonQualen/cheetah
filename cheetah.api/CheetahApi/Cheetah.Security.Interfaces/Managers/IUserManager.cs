using System.Threading.Tasks;
using Cheetah.Security.Interfaces.Models;
using Cheetah.Security.Interfaces.Models.Base;
using Cheetah.Security.Interfaces.Stores;

namespace Cheetah.Security.Interfaces.Managers
{
    public interface IUserManager<TUser, TAccessToken, TRefreshToken> 
        where TUser : IUser 
        where TAccessToken : IExpirableToken 
        where TRefreshToken : IToken
    {
        ITokenStore<TAccessToken> AccessTokenStore { get; set; }
        ITokenStore<TRefreshToken> RefreshTokenStore { get; set; }  
        IUserStore<TUser> UserStore { get; set; }

        void Create(TUser user);
        IAuthorizationGrant Authorize(ILocalAuthRequest authRequest);
        TAccessToken Refresh(IRefreshRequest<TRefreshToken> refreshRequest);
        IAuthenticationResponse Authenticate(TAccessToken accessToken);

        Task CreateAsync(TUser user);
        Task<IAuthorizationGrant> AuthorizeAsync(ILocalAuthRequest authRequest);
        Task<TAccessToken> RefreshAsync(IRefreshRequest<TRefreshToken> refreshRequest);
        Task<IAuthenticationResponse> AuthenticateAsync(TAccessToken accessToken);
    }
}