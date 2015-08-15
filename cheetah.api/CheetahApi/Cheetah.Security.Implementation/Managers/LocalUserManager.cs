using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Implementation.Exceptions;
using Cheetah.Security.Implementation.Models;
using Cheetah.Security.Interfaces.Managers;
using Cheetah.Security.Interfaces.Models;
using Cheetah.Security.Interfaces.Models.Base;
using Cheetah.Security.Interfaces.Stores;
using Cheetah.Security.Interfaces.Utils;
using Task = System.Threading.Tasks.Task;

namespace Cheetah.Security.Implementation.Managers
{
    public class LocalUserManager : ILocalUserManager<User, AccessToken, RefreshToken>
    {
        public ITokenStore<AccessToken> AccessTokenStore { get; set; }
        public ITokenStore<RefreshToken> RefreshTokenStore { get; set; }
        public IUserStore<User> UserStore { get; set; }
        public IHasher Hasher { get; set; }
        public IPasswordHasher PasswordHasher { get; set; }
        public ITokenGenerator TokenGenerator { get; set; }

        public LocalUserManager(
            ITokenStore<AccessToken> accessTokenStore,
            ITokenStore<RefreshToken> refreshTokenStore,
            IUserStore<User> userStore,
            IHasher hasher,
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator
            )
        {
            AccessTokenStore = accessTokenStore;
            RefreshTokenStore = refreshTokenStore;
            UserStore = userStore;
            Hasher = hasher;
            PasswordHasher = passwordHasher;
            TokenGenerator = tokenGenerator;
        }

        public RefreshToken Create(User user, string password)
        {
            var newUser = UserStore.Create(user);
            var hashedPassword = PasswordHasher.HashPassword(password);

            UserStore.SetPasswordHash(newUser.UserId, hashedPassword);

            var newToken = RefreshTokenStore.Create(new RefreshToken()
            {
                UserId = newUser.UserId,
                Token = TokenGenerator.Generate(newUser, hashedPassword)
            });

            return newToken;
        }

        public IAuthorizationGrant Authorize(ILocalAuthRequest authRequest)
        {
            var user = UserStore.Find(authRequest.Username);
            var correctHash = UserStore.FindPasswordHash(user.UserId);
            var valid = PasswordHasher.Verify(authRequest.Password, correctHash);
            
            if (!valid)
                throw new InvalidCredentials();

            var refreshToken = RefreshTokenStore.Find(user.UserId);

            var grant = new AuthorizationGrant
            {
                ClientId = user.ClientId,
                RefreshToken = refreshToken
            };

            return grant;
        }

        public AccessToken Refresh(IRefreshRequest<RefreshToken> refreshRequest)
        {
            var correctToken = RefreshTokenStore.Find(refreshRequest.RefreshToken.Token);

            if (correctToken == null)
                throw new InvalidRefreshToken();

            var user = UserStore.Find(correctToken.UserId);
            var passwordHash = UserStore.FindPasswordHash(user.UserId);

            AccessTokenStore.Revoke(correctToken.UserId);

            var accessToken = AccessTokenStore.Create(new AccessToken()
            {
                UserId = user.UserId,
                Token = TokenGenerator.Generate(user, passwordHash),
                Expires = DateTime.UtcNow.AddHours(12)
            });

            return accessToken;
        }

        public IAuthenticationResponse Authenticate(string accessToken)
        {
            var existing = AccessTokenStore.Find(accessToken);

            if (existing == null)
                throw new InvalidAccessToken();

            if (Hasher.SlowEquals(existing.Token, accessToken))
            {
                return new AuthenticationResponse()
                {
                    IsValid = true
                };
            }
            else
            {
                throw new InvalidAccessToken();
            }            
        }

        public async Task<RefreshToken> CreateAsync(User user, string password)
        {
            var newUser = await UserStore.CreateAsync(user);
            var hashedPassword = PasswordHasher.HashPassword(password);

            await UserStore.SetPasswordHashAsync(newUser.UserId, hashedPassword);

            var newToken = await RefreshTokenStore.CreateAsync(new RefreshToken()
            {
                UserId = newUser.UserId,
                Token = TokenGenerator.Generate(newUser, hashedPassword)
            });

            return newToken;
        }

        public async Task<IAuthorizationGrant> AuthorizeAsync(ILocalAuthRequest authRequest)
        {
            var user = await UserStore.FindAsync(authRequest.Username);
            var correctHash = await UserStore.FindPasswordHashAsync(user.UserId);
            var valid = PasswordHasher.Verify(authRequest.Password, correctHash);

            if (!valid)
                throw new InvalidCredentials();

            var refreshToken = await RefreshTokenStore.FindAsync(user.UserId);

            var grant = new AuthorizationGrant
            {
                ClientId = user.ClientId,
                RefreshToken = refreshToken
            };

            return grant;
        }

        public async Task<AccessToken> RefreshAsync(IRefreshRequest<RefreshToken> refreshRequest)
        {
            var correctToken = await RefreshTokenStore.FindAsync(refreshRequest.RefreshToken.Token);

            if (correctToken == null)
                throw new InvalidRefreshToken();

            var user = await UserStore.FindAsync(correctToken.UserId);
            var passwordHash = await UserStore.FindPasswordHashAsync(user.UserId);

            await AccessTokenStore.RevokeAsync(correctToken.UserId);

            var accessToken = await AccessTokenStore.CreateAsync(new AccessToken()
            {
                UserId = user.UserId,
                Token = TokenGenerator.Generate(user, passwordHash),
                Expires = DateTime.UtcNow.AddHours(12)
            });

            return accessToken;
        }

        public async Task<IAuthenticationResponse> AuthenticateAsync(string accessToken)
        {
            var existing = await AccessTokenStore.FindAsync(accessToken);

            if (existing == null)
                throw new InvalidAccessToken();

            if (Hasher.SlowEquals(existing.Token, accessToken))
            {
                return new AuthenticationResponse()
                {
                    IsValid = true
                };
            }
            else
            {
                throw new InvalidAccessToken();
            }
        }
    }
}