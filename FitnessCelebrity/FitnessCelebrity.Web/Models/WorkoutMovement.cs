using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class WorkoutMovement
    {
        public int MovementId { get; set; }
        public Movement Movement { get; set; }

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}
