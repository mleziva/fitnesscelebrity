using FitnessCelebrity.Web.Dto.Workout;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Dto.Movement
{
    public class DtoMovementGet : DtoBase
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string CreatedByUserName { get; set; }
        public IList<DtoWorkoutLink> Workouts { get; set; }
    }
}
