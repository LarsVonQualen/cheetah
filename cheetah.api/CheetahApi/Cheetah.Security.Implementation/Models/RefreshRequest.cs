using Cheetah.DataAccess.Models;
using Cheetah.Security.Interfaces.Models;

namespace Cheetah.Security.Implementation.Models
{
    public class RefreshRequest : IRefreshRequest<RefreshToken>
    {
        public string ClientId { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}