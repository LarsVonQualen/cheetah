﻿using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Repositories
{
    class ProjectRepository : BaseRepository<int, Project>, IProjectRepository
    {
         
    }
}