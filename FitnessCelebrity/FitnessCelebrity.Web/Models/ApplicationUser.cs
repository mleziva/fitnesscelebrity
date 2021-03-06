﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IList<FitnessPath> CreatedFitnessPaths { get; set; }
        public virtual IList<Workout> CreatedWorkouts { get; set; }
        public virtual IList<Movement> CreatedMovements { get; set; }

        public virtual IList<FitnessPath> ModifiedFitnessPaths { get; set; }
        public virtual IList<Workout> ModifiedWorkouts { get; set; }
        public virtual IList<Movement> ModifiedMovements { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual IList<UserProfile> CreatedUserProfiles { get; set; }
        public virtual IList<UserProfile> ModifiedUserProfiles { get; set; }


        public virtual IList<FitnessPathSubscription> FitnessPathSubscriptions { get; set; }
        public virtual IList<UserSubscription> UserSubscriptions { get; set; }
        public virtual IList<WorkoutSubscription> WorkoutSubscriptions { get; set; }

        public virtual IList<WorkoutHistory> WorkoutHistories { get; set; }
        public virtual IList<FitnessPathHistory> FitnessPathHistories { get; set; }
        public virtual IList<DailyLog> DailyLogs { get; set; }

        public virtual IList<FitnessPathWorkout> CreatedFitnessPathWorkouts { get; set; }
        public virtual IList<FitnessPathWorkout> ModifiedFitnessPathWorkouts { get; set; }

    }
}
