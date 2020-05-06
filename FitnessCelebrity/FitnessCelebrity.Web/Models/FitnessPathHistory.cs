using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class FitnessPathHistory : BaseDateData
    {
        public long FitnessPathId { get; set; }
        public string UserId { get; set; }
        public PrivacyStates Privacy { get; set; }
        public HistoryStates State { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? StartedDate { get; set; }
        public DateTimeOffset? CompletedDate { get; set; }
        public ApplicationUser User { get; set; }
        public FitnessPath FitnessPath { get; set; }
        public IEnumerable<WorkoutHistory> WorkoutHistories { get; set; }

    }
}
