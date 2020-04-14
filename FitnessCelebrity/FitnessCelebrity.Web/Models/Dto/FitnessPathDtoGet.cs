using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class FitnessPathDtoGet : BasePostDtoCreate
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string CreatedByUserName { get; set; }
        public IList<FitnessPathDtoGetWorkouts> Workouts { get; set; }
    }
    public class FitnessPathDtoGetWorkouts
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
