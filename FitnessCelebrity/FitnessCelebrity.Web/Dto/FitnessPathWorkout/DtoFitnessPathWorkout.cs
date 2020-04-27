using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Dto.FitnessPathWorkout
{
    public class DtoFitnessPathWorkout
    {
        public long FitnessPathId { get; set; }
        public long WorkoutId { get; set; }
        //Sun, Mon, Tues, Week 1
        public string DayOfWeek { get; set; }
        public int? Week { get; set; }
        //specific date
        public DateTimeOffset? Date { get; set; }
        //order
        public int? WorkoutOrder { get; set; }
        public string Notes { get; set; }

    }
}
