using System;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Interfaces.Models
{
    public interface IAuthorizationGrant
    {
        Guid ClientId { get; set; }
        IToken RefreshToken { get; set; } 
    }
}