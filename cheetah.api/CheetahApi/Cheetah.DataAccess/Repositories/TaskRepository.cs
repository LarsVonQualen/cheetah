﻿using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using Cheetah.DataAccess.Models;

namespace Cheetah.DataAccess.Repositories
{
    class TaskRepository : BaseRepository<int, Task>, ITaskRepository
    {
         
    }
}