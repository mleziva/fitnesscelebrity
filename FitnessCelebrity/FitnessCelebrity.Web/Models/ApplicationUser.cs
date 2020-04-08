using Microsoft.AspNetCore.Identity;
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

    }
}
