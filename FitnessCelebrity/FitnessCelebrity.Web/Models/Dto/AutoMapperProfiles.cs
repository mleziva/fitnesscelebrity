using AutoMapper;
using FitnessCelebrity.Web.Models.Dto.UserProfile;
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
            //Mapper.Map<Dest>(src, opt => { opt.Items["UserId"] = "my-guid-123";});
            CreateMap<MovementDtoCreate, Movement>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(d => d.CreatedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]))
                .ForMember(d => d.ModifiedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]));
            CreateMap<WorkoutDtoCreate, Workout>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(d => d.CreatedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]))
                .ForMember(d => d.ModifiedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]));
            CreateMap<FitnessPathDtoCreate, FitnessPath>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(d => d.CreatedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]))
                .ForMember(d => d.ModifiedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]));
            CreateMap<FitnessPathWorkoutDtoCreate, FitnessPathWorkout>();
            CreateMap<WorkoutMovementDtoCreate, WorkoutMovement>();

            CreateMap<FitnessPath, FitnessPathDtoGet>()
                .ForMember(x => x.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.UserProfile.UserName))
                .ForMember(x => x.Workouts, opt => opt.MapFrom(src => src.FitnessPathWorkouts.Select(w => w.Workout)));

            CreateMap<Workout, FitnessPathDtoGetWorkouts>();

            CreateMap<DtoCreateUserProfile, Models.UserProfile>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow));

        }
    }
}
