using System;
using Cheetah.Security.Interfaces.Models;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Implementation.Models
{
    public class AuthorizationGrant : IAuthorizationGrant
    {
        public Guid ClientId { get; set; }
        public IToken RefreshToken { get; set; }
    }
}