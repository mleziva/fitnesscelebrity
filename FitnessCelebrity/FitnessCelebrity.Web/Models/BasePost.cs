using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models
{
    public class BasePost : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}
