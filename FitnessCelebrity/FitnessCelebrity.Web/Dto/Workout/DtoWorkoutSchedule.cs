using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Dto.Workout
{
    public class DtoWorkoutSchedule
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public string DayOfWeek { get; set; }
        public int? Week { get; set; }
        //specific date
        public DateTimeOffset? Date { get; set; }
        //order
        public int? WorkoutOrder { get; set; }
        public string Notes { get; set; }
    }
}
