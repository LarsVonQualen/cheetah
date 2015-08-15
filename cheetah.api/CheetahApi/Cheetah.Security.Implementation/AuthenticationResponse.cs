using Cheetah.Security.Interfaces.Models;

namespace Cheetah.Security.Implementation
{
    public class AuthenticationResponse : IAuthenticationResponse
    {
        public bool IsValid { get; set; }
    }
}