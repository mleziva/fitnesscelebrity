using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class WorkoutHistory : BaseDateData
    {
        public long WorkoutId { get; set; }
        public long FitnessPathId { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPrivate { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public DateTimeOffset CompletedDate { get; set; }
        public ApplicationUser User { get; set; }
        public Workout Workout { get; set; }
        public FitnessPath FitnessPath { get; set; }
        public IEnumerable<DailyLog> DailyLogs { get; set; }
    }
}
