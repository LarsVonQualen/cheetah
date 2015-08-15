using System;
using Cheetah.Security.Interfaces.Models;
using Cheetah.Security.Interfaces.Utils;

namespace Cheetah.Security.Implementation.Utils
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IHasher _hasher;

        public TokenGenerator(
            IHasher hasher
            )
        {
            _hasher = hasher;
        }

        public string Generate(IUser user, string passwordHash)
        {
            var random = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 32);

            return _hasher.CreateHash($"{random}+{user.UserId}+{user.ClientId}+{DateTime.UtcNow}+{passwordHash}");
        }
    }
}