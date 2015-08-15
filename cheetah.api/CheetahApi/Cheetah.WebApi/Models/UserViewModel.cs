using Cheetah.DataAccess.Models;

namespace Cheetah.WebApi.Models
{
    public class UserViewModel
    {
        public User Info { get; set; }
        public string Password { get; set; }
    }
}