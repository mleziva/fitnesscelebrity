using AutoMapper;
using FitnessCelebrity.Web.Dto.FitnessPath;
using FitnessCelebrity.Web.Dto.FitnessPathWorkout;
using FitnessCelebrity.Web.Dto.Movement;
using FitnessCelebrity.Web.Dto.Workout;
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
            //CreateMap<Source, Destination>
            #region dto create

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
            #endregion


            //fitness path - post
            CreateMap<DtoFitnessPathCreate, FitnessPath>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(d => d.CreatedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]))
                .ForMember(d => d.ModifiedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]));

            //user profile
            CreateMap<DtoCreateUserProfile, Models.UserProfile>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow));

            #region movement controller
            
            CreateMap<Movement, DtoMovementLink>();
            //Get
            CreateMap<Movement, DtoMovementGet>()
                .ForMember(x => x.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.UserProfile.UserName))
                .ForMember(x => x.Workouts, opt => opt.MapFrom(src => src.WorkoutMovements.Select(w => w.Workout)));

            #endregion

            #region workout controller
            //general
            CreateMap<Workout, DtoWorkoutLink>();
         
            //Get
            CreateMap<Workout, DtoWorkoutGet>()
                .ForMember(x => x.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.UserProfile.UserName))
                .ForMember(x => x.FitnessPaths, opt => opt.MapFrom(src => src.FitnessPathWorkouts.Select(w => w.FitnessPath)))
                .ForMember(x => x.Movements, opt => opt.MapFrom(src => src.WorkoutMovements.Select(w => w.Movement)));

            //update
            CreateMap<DtoWorkoutGet, Workout>()
                .ForMember(x => x.ModifiedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.FitnessPathWorkouts, opt => opt.MapFrom(src => src.FitnessPaths));

            CreateMap<DtoFitnessPathLink, FitnessPathWorkout>()
                .ForMember(d => d.FitnessPathId, opt => opt.MapFrom(s => s.Id));

            #endregion

            #region fitnesspath controller
            CreateMap<FitnessPath, DtoFitnessPathLink>();
            //Get
            CreateMap<FitnessPath, DtoFitnessPath>()
                .ForMember(x => x.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.UserProfile.UserName))
                .ForMember(x => x.Workouts, opt => opt.MapFrom(src => src.FitnessPathWorkouts));


            //update
            CreateMap<DtoFitnessPath, FitnessPath>()
                .ForMember(x => x.ModifiedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.FitnessPathWorkouts, opt => opt.MapFrom(src => src.Workouts));

            CreateMap<DtoWorkoutLink, FitnessPathWorkout>()
                .ForMember(d => d.WorkoutId, opt => opt.MapFrom(s => s.Id));
            #endregion


            //fitnesspathworkout
            //general
            CreateMap<FitnessPathWorkout, DtoWorkoutSchedule>()
             .ForMember(x => x.Id, opt => opt.MapFrom(src => src.WorkoutId))
             .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Workout.Name));
            //insert
            CreateMap<DtoFitnessPathWorkout, FitnessPathWorkout>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(o => DateTimeOffset.UtcNow))
                .ForMember(d => d.CreatedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]))
                .ForMember(d => d.ModifiedById, opt => opt.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]));
            
            

        }
    }
}
