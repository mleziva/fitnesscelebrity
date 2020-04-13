using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class SubscribedFitnessPaths
    {
        public long ApplicationUserId { get; set; }
        public long FitnessPathId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public FitnessPath FitnessPath { get; set; }
    }
}
