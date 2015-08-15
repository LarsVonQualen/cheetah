using System;
using Cheetah.Security.Interfaces.Models.Base;

namespace Cheetah.Security.Interfaces.Models
{
    public interface IExpirableToken : IToken
    {
        DateTime Expires { get; set; }
    }
}