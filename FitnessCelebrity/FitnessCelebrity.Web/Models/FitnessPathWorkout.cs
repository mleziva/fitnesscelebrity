using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class FitnessPathWorkout
    {
        public int FitnessPathId { get; set; }
        public FitnessPath FitnessPath { get; set; }

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}
