using FitnessCelebrity.Web.Dto.FitnessPath;
using FitnessCelebrity.Web.Dto.Movement;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Dto.Workout
{
    public class DtoWorkoutGet : DtoBase
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string CreatedByUserName { get; set; }
        public IList<DtoMovementLink> Movements { get; set; }
        public IList<DtoFitnessPathLink> FitnessPaths { get; set; }
    }
}
