namespace Cheetah.Security.Interfaces.Models.Base
{
    public interface IToken
    {
        string Type { get; }
        string Token { get; set; } 
    }
}