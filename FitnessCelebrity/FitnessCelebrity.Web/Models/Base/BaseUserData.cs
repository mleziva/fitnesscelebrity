using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class BaseUserData : BaseDateData
    {
        public string CreatedById { get; set; }
        public string ModifiedById { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser ModifiedByUser { get; set; }
    }
}
