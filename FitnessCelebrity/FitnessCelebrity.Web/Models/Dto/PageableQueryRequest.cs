using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class PageableQueryRequest : PageableRequest
    {
        public string Query { get; set; }
    }
}
