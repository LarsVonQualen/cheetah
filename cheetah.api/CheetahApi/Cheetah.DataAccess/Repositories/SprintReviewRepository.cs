using System;
using Cheetah.DataAccess.Interfaces;
using Cheetah.DataAccess.Repositories.Base;
using CheetahPocoModel;

namespace Cheetah.DataAccess.Repositories
{
    class SprintReviewRepository : BaseRepository<int, SprintReview, Guid>, ISprintReviewRepository
    {
         
    }
}