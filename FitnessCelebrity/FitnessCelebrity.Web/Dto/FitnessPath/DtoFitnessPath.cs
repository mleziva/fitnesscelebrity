﻿using FitnessCelebrity.Web.Dto.Workout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class DtoFitnessPath : DtoBase
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string CreatedByUserName { get; set; }
        public IList<DtoWorkoutLink> Workouts { get; set; }
    }
}
