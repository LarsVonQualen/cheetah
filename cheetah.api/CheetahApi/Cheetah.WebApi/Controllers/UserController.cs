using System;
using System.Collections.Generic;
using System.Web.Http;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Models;
using Cheetah.Security.Implementation.Utils;
using Cheetah.WebApi.Controllers.Base;
using Ninject;

namespace Cheetah.WebApi.Controllers
{
    [RoutePrefix("v1/user")]
    [CheetahAuthorize]
    public class UserController : TwoKeyRepositoryController<int, Guid, User, IUserRepository>
    {
        [Inject]
        public ITeamRepository TeamRepository { get; set; }

        /// <summary>
        /// Fetches the teams that are associated with the user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("{userId:alpha}/teams")]
        [HttpGet]
        public ICollection<Team> Teams(Guid userId)
        {
            return TeamRepository.GetByUserId(userId);
        }

        [Route("{primaryKey:int}")]        
        public override User Get(int primaryKey)
        {
            return base.Get(primaryKey);
        }

        [Route("{primaryKey:int}")]
        public override void Delete(int primaryKey)
        {
            base.Delete(primaryKey);
        }

        [Route("{secondaryKey:alpha}")]
        public override User Get(Guid secondaryKey)
        {
            return base.Get(secondaryKey);
        }

        [Route("{secondaryKey:alpha}")]
        public override void Delete(Guid secondaryKey)
        {
            base.Delete(secondaryKey);
        }
    }
}