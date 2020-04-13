using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class PageableRequest
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 50;
    }
}
