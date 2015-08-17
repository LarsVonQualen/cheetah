using Cheetah.DataAccess.Models;

namespace Cheetah.WebApi.Models
{
    public class UserInfoViewModel
    {
        public User User { get; set; }
        public RefreshToken RefreshToken { get; set; } 
    }
}