using Cheetah.Security.Interfaces.Models;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Implementation
{
    public class AuthorizationGrant : IAuthorizationGrant
    {
        public string ClientId { get; set; }
        public IToken RefreshToken { get; set; }
    }
}