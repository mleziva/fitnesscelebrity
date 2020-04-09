using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class WorkoutDtoCreate : BasePostDtoCreate
    {
        public string Category { get; set; }
        public IList<FitnessPathWorkoutDtoCreate> FitnessPathWorkouts { get; set; }
        public IList<WorkoutMovementDtoCreate> WorkoutMovements { get; set; }

        //potentially move all create DTO into a single file and remove nested fitnessPathWorkouts and workoutMovements
    }
}
