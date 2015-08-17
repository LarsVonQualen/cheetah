using Cheetah.Security.Interfaces;
using Cheetah.Security.Interfaces.Models;

namespace Cheetah.DataAccess.Models
{
    public partial class User : IUser
    {
        public UserProfile UserProfile { get; set; }
    }
}