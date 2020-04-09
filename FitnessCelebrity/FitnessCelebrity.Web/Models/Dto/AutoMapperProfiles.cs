using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Models.Dto
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MovementDtoCreate, Movement>();
            CreateMap<WorkoutDtoCreate, Workout>();
            CreateMap<FitnessPathDtoCreate, FitnessPath>();
            CreateMap<FitnessPathWorkoutDtoCreate, FitnessPathWorkout>();
            CreateMap<WorkoutMovementDtoCreate, WorkoutMovement>();
        }
    }
}
