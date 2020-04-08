﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class FitnessPathDtoCreate : BasePostDtoCreate
    {
        public string Category { get; set; }
        public IList<FitnessPathWorkout> FitnessPathWorkouts { get; set; }
    }
}
