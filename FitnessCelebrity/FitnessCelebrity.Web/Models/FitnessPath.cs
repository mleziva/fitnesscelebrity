﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class FitnessPath : BasePost
    {
        public string Category { get; set; }
        public virtual IList<FitnessPathWorkout> FitnessPathWorkouts { get; set; }
        public virtual IList<FitnessPathSubscription> Subscriptions { get; set; }
        public virtual IList<WorkoutHistory> WorkoutHistories { get; set; }

    }
}
