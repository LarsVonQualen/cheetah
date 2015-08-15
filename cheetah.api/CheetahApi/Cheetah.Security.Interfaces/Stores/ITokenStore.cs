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
        void Revoke(Guid userId);

        Task<TToken> FindAsync(Guid userId);
        Task<TToken> FindAsync(string token);
        Task<TToken> CreateAsync(TToken token);
        Task RevokeAsync(Guid userId);
    }
}