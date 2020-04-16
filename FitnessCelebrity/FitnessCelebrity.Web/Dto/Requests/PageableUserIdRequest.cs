using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class PageableUserIdRequest : PageableRequest
    {
        public string UserId { get; set; }
    }
}
