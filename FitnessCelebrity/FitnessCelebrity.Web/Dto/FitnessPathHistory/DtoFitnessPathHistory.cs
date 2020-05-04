using FitnessCelebrity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Dto.FitnessPathHistory
{
    public class DtoFitnessPathHistory
    {
        public long FitnessPathId { get; set; }
        public string UserId { get; set; }
        public PrivacyStates Privacy { get; set; }
        public HistoryStates State { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public DateTimeOffset CompletedDate { get; set; }
    }
}
