using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class FitnessPathDtoCreate : DtoBase
    {
        public string Category { get; set; }
        public IList<FitnessPathWorkoutDtoCreate> FitnessPathWorkouts { get; set; }
    }
}
