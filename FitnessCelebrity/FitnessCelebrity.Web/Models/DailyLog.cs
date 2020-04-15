using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class DailyLog : BaseDateData
    {
        public long WorkoutHistoryId { get; set; }
        public long UserId { get; set; }
        public int TimeSpent { get; set; }
        public string Notes { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPrivate { get; set; }
    }
}
