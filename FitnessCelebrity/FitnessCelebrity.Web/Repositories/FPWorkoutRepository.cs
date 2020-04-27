using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class FPWorkoutRepository : BaseRepository<FitnessPathWorkout>, IFPWorkoutRepository
    {
        public FPWorkoutRepository(ApplicationDbContext dbContext)
: base(dbContext)
        {

        }
        public async Task UpdateWorkouts(long id, IList<FitnessPathWorkout> fitnessPathWorkouts)
        {
            var newWorkouts = fitnessPathWorkouts;
            var existingFitnessPath = await _dbContext.FitnessPaths.FirstOrDefaultAsync(u => u.Id == id);
            if (existingFitnessPath == null)
            {
                //not found, can't update
                return;
            }
            var existingWorkouts = existingFitnessPath.FitnessPathWorkouts;
            existingFitnessPath.FitnessPathWorkouts = newWorkouts;
            await _dbContext.SaveChangesAsync();
        }
    }
}
