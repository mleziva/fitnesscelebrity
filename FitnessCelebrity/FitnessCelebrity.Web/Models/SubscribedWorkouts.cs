using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class SubscribedWorkouts
    {
        public long ApplicationUserId { get; set; }
        public long WorkoutId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Workout Workout { get; set; }
    }
}
