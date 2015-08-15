namespace Cheetah.Security.Interfaces.Utils
{
    public interface IHasher
    {
        string CreateHash(string toHash);
        bool Validate(string nonHashed, string correctHash);
        bool SlowEquals(string a, string b);
    }
}