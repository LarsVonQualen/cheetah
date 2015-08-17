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
    }
}