using System;
using System.Text;
using System.Security.Cryptography;
using Cheetah.Security.Interfaces.Utils;

namespace Cheetah.Security.Implementation.Utils
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly IHasher _hasher;

        public PasswordHasher(
            IHasher hasher
            )
        {
            _hasher = hasher;
        }

        public string HashPassword(string password)
        {
            return _hasher.CreateHash(password);
        }

        public bool Verify(string password, string correctHash)
        {
            return _hasher.Validate(password, correctHash);
        }
    }
}