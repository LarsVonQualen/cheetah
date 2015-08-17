using Cheetah.Security.Interfaces.Models;

namespace Cheetah.Security.Interfaces.Utils
{
    public interface ITokenGenerator
    {
        string Generate(IUser user, string passwordHash);
    }
}