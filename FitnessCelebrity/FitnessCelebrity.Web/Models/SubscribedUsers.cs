using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class SubscribedUsers
    {
        public long ApplicationUserId { get; set; }
        public long UserProfileId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
