using FitnessCelebrity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories.Interfaces
{
    public interface IFPWorkoutRepository : IBaseRepository<FitnessPathWorkout>
    {
        Task UpdateWorkouts(long id, IList<FitnessPathWorkout> fitnessPathWorkouts);
    }
}
