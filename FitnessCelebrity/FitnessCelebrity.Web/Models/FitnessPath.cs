using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class FitnessPath : BasePost
    {
        public string Category { get; set; }
        public WorkoutSchedule WorkoutSchedule { get; set; }
        public virtual IList<FitnessPathWorkout> FitnessPathWorkouts { get; set; }
        public virtual IList<FitnessPathSubscription> Subscriptions { get; set; }
        public virtual IList<FitnessPathHistory> FitnessPathHistories { get; set; }

    }
    public enum WorkoutSchedule
    {
        Ordered,
        Date,
        Weekday
    }
}
