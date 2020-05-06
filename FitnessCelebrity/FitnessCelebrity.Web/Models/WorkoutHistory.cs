using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class WorkoutHistory : BaseDateData
    {
        public long WorkoutId { get; set; }
        public long? FitnessPathHistoryId { get; set; }
        public string UserId { get; set; }
        public PrivacyStates Privacy { get; set; }
        public HistoryStates State { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? StartedDate { get; set; }
        public DateTimeOffset? CompletedDate { get; set; }
        public ApplicationUser User { get; set; }
        public Workout Workout { get; set; }
        public FitnessPathHistory FitnessPathHistory { get; set; }
        public IEnumerable<DailyLog> DailyLogs { get; set; }
    }
    public enum HistoryStates
    {
        Inactive,
        Active,
        Completed
    }
}
