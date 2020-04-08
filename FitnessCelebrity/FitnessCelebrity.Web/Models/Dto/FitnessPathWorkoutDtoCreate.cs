using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class FitnessPathWorkoutDtoCreate
    {
        public long FitnessPathId { get; set; }
        public FitnessPathDtoCreate FitnessPath { get; set; }

        public long WorkoutId { get; set; }
        public WorkoutDtoCreate Workout { get; set; }
    }
}
