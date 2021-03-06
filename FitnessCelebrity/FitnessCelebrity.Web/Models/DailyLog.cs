﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class DailyLog : BaseDateData
    {
        public long WorkoutHistoryId { get; set; }
        public string UserId { get; set; }
        public int TimeSpent { get; set; }
        public string Notes { get; set; }
        public PrivacyStates Privacy { get; set; }
        public ApplicationUser User { get; set; }
        public WorkoutHistory WorkoutHistory { get; set; }
    }
}
