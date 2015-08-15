using Cheetah.Security.Interfaces.Models;

namespace Cheetah.Security.Implementation.Models
{
    public class AuthenticationResponse : IAuthenticationResponse
    {
        public bool IsValid { get; set; }
    }
}