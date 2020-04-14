using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class UserSubscription : BaseDateData
    {
        public string ApplicationUserId { get; set; }
        public long UserProfileId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
