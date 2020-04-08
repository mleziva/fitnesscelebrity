using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
        public string CreatedById { get; set; }
        public string ModifiedById { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
