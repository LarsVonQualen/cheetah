namespace Cheetah.Security.Interfaces.Utils
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool Verify(string password, string correctHash);
    }
}