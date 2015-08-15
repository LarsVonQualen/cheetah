using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Interfaces.Models
{
    public interface IAuthorizationGrant
    {
        string ClientId { get; set; }
        IToken RefreshToken { get; set; } 
    }
}