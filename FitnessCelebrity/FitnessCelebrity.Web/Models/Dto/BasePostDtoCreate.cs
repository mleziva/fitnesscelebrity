using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class BasePostDtoCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
    }
}
