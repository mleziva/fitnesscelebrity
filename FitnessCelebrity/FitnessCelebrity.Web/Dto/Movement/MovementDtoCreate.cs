using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class MovementDtoCreate : DtoBase
    {
        public string Type { get; set; }

        public IList<WorkoutMovementDtoCreate> WorkoutMovements { get; set; }
    }
}
