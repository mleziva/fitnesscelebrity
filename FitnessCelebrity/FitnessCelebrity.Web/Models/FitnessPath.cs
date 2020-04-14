using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class FitnessPath : BasePost
    {
        public string Category { get; set; }
        public virtual IEnumerable<FitnessPathWorkout> FitnessPathWorkouts { get; set; }
        public virtual IEnumerable<FitnessPathSubscription> Subscriptions { get; set; }
    }
}
