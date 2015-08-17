using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Interfaces.Models
{
    public interface ILocalAuthRequest : IAuthRequest
    {
        string Username { get; set; }
        string Password { get; set; } 
    }
}