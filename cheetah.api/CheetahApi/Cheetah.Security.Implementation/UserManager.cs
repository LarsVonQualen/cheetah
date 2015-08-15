using System.Threading.Tasks;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Interfaces.Managers;
using Cheetah.Security.Interfaces.Models;
using Cheetah.Security.Interfaces.Stores;
using Task = System.Threading.Tasks.Task;

namespace Cheetah.Security.Implementation
{
    public class UserManager : IUserManager<User, AccessToken, RefreshToken>
    {
        public ITokenStore<AccessToken> AccessTokenStore { get; set; }
        public ITokenStore<RefreshToken> RefreshTokenStore { get; set; }
        public IUserStore<User> UserStore { get; set; }

        public UserManager(
            ITokenStore<AccessToken> accessTokenStore,
            ITokenStore<RefreshToken> refreshTokenStore,
            IUserStore<User> userStore   
            )
        {
            AccessTokenStore = accessTokenStore;
            RefreshTokenStore = refreshTokenStore;
            UserStore = userStore;
        }

        public void Create(User user)
        {
            throw new System.NotImplementedException();
        }

        public IAuthorizationGrant Authorize(ILocalAuthRequest authRequest)
        {
            throw new System.NotImplementedException();
        }

        public AccessToken Refresh(IRefreshRequest<RefreshToken> refreshRequest)
        {
            throw new System.NotImplementedException();
        }

        public IAuthenticationResponse Authenticate(AccessToken accessToken)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAuthorizationGrant> AuthorizeAsync(ILocalAuthRequest authRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccessToken> RefreshAsync(IRefreshRequest<RefreshToken> refreshRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAuthenticationResponse> AuthenticateAsync(AccessToken accessToken)
        {
            throw new System.NotImplementedException();
        }
    }
}