using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class UserProfile : BaseModel
    {
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public string Tags { get; set; }
        public bool IsPublic { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual IEnumerable<SubscribedUsers> Subscriptions { get; set; }

    }
}
