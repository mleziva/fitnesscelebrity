using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class FitnessPathWorkout : BaseUserData
    {
        public long FitnessPathId { get; set; }
        public FitnessPath FitnessPath { get; set; }

        public long WorkoutId { get; set; }
        public Workout Workout { get; set; }
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
