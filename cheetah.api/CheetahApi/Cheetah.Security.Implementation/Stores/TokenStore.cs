using System;
using System.Threading.Tasks;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Interfaces.Models.Base;
using Cheetah.Security.Interfaces.Stores;
using Task = System.Threading.Tasks.Task;

namespace Cheetah.Security.Implementation.Stores
{
    public class TokenStore<TToken, TTokenRepository> : 
        ITokenStore<TToken> 
        where TToken : class, IToken, new()
        where TTokenRepository : ITokenRepository<TToken>
    {
        private readonly TTokenRepository _tokenRepository;

        public TokenStore(
            TTokenRepository tokenRepository
            )
        {
            _tokenRepository = tokenRepository;
        }

        public TToken Find(Guid userId)
        {
            return _tokenRepository.Get(userId);
        }

        public TToken Find(string token)
        {
            return _tokenRepository.Get(token);
        }

        public TToken Create(TToken token)
        {
            return _tokenRepository.Save(token);
        }

        public void Revoke(Guid userId)
        {
            _tokenRepository.Delete(userId);
        }
    }
}