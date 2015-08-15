using Cheetah.Security.Interfaces;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.DataAccess.Models
{
    public partial class RefreshToken : IToken
    {
        public string Type => "refresh";
    }
}