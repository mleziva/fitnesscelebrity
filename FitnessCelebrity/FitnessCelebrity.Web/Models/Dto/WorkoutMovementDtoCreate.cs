using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class WorkoutMovementDtoCreate
    {
        public long MovementId { get; set; }
        public MovementDtoCreate Movement { get; set; }

        public long WorkoutId { get; set; }
        public WorkoutDtoCreate Workout { get; set; }
    }
}
