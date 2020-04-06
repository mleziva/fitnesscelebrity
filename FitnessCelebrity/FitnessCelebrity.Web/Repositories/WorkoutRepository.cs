using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(FitnessDbContext dbContext)
      : base(dbContext)
        {

        }

        public Task<Workout> GetWorkouts()
        {
            throw new NotImplementedException();
        }
    }
}
