using System;
using System.Threading.Tasks;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Interfaces.Stores
{
    public interface ITokenStore<TToken> where TToken : IToken
    {
        TToken Find(Guid userId);
        TToken Find(string token);
        TToken Create(TToken token);

        Task<TToken> FindAsync(Guid userId);
        Task<TToken> FindAsync(string token);
        Task<TToken> CreateAsync(TToken token);
    }
}