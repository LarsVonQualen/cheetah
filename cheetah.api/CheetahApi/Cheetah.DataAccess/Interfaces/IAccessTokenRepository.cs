﻿using System;
using Cheetah.DataAccess.Interfaces.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Interfaces
{
    public interface IAccessTokenRepository :
        ITokenRepository<AccessToken>
    {
         
    }
}