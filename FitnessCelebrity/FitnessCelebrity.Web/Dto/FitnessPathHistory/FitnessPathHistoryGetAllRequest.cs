using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Dto.FitnessPathHistory
{
    public class FitnessPathHistoryGetAllRequest : PageableUserIdRequest
    {
        public HistoryStates? State { get; set; }
        public long? FitnessPathId { get; set; }
    }
}
