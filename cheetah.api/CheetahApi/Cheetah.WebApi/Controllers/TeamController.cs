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
    [RoutePrefix("v1/team")]
    [CheetahAuthorize]
    public class TeamController :
        RepositoryController<int, Team, ITeamRepository>
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        /// <summary>
        /// Fetches the users that are associated with the team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [Route("{teamId:int}/users")]
        [HttpGet]
        public ICollection<User> Users(int teamId)
        {
            return UserRepository.GetByTeam(teamId);
        }

        [Route("{primaryKey:int}")]
        public override Team Get(int primaryKey)
        {
            return base.Get(primaryKey);
        }

        [Route("{primaryKey:int}")]
        public override void Delete(int primaryKey)
        {
            base.Delete(primaryKey);
        }
    }
}