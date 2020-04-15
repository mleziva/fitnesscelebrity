using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {

        }

        public async Task<PagingList<Workout>> Get(PageableUserIdRequest request)
        {
            return await PagingList<Workout>.CreateAsync(GetAll().Where(x => x.CreatedById == request.UserId), request.Page, request.Size);
        }
        public async Task<PagingList<Workout>> SearchWorkouts(PageableQueryRequest request)
        {
            return await PagingList<Workout>.CreateAsync(GetAll()
                .Where(x => x.Tags.Contains(request.Query)), request.Page, request.Size);
        }
    }
}
