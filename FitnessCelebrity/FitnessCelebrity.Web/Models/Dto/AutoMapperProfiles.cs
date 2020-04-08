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
            CreateMap<Movement, MovementDtoCreate>();
            CreateMap<Workout, WorkoutDtoCreate>();
            CreateMap<FitnessPath, FitnessPathDtoCreate>();
            CreateMap<FitnessPathWorkout, FitnessPathWorkoutDtoCreate>();
            CreateMap<WorkoutMovement, WorkoutMovementDtoCreate>();
        }
    }
}
