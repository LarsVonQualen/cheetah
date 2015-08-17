using Cheetah.Security.Interfaces.Models;

namespace Cheetah.Security.Implementation.Models
{
    public class LocalAuthRequest : ILocalAuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}