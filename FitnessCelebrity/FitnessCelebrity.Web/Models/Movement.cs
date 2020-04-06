using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class Movement : BasePost
    {
        public string Type { get; set; }

        public IList<WorkoutMovement> WorkoutMovements { get; set; }
    }
}
