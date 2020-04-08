using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IList<FitnessPath> FitnessPaths { get; set; }
        public virtual IList<Workout> Workouts { get; set; }
        public virtual IList<Movement> Movements { get; set; }

    }
}
