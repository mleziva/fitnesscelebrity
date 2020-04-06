using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class Workout : BaseModel
    {
        public string Category { get; set; }
        public IList<FitnessPathWorkout> FitnessPathWorkouts { get; set; }
        public IList<WorkoutMovement> WorkoutMovements { get; set; }
    }
}
