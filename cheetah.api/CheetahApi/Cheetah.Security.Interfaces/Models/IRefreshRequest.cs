using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Interfaces.Models
{
    public interface IRefreshRequest<TToken> where TToken : IToken
    {
        string ClientId { get; set; }
        TToken RefreshToken { get; set; } 
    }
}