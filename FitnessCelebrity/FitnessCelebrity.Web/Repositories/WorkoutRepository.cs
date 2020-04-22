using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {

        }

        public async Task<PagingList<Workout>> Get(PageableUserIdRequest request)
        {
            return await PagingList<Workout>.CreateAsync(GetAll().Where(x => x.CreatedById == request.UserId), request.Page, request.Size);
        }

        public async Task UpdateFitnessPaths(long id, Workout workout)
        {
            var newFitnessPaths = workout.FitnessPathWorkouts;
            var existingWorkout = await _dbContext.Workouts.Include(p => p.FitnessPathWorkouts).FirstOrDefaultAsync(u => u.Id == id);
            if (existingWorkout == null)
            {
                //not found, can't update
                return;
            }
            if (!existingWorkout.FitnessPathWorkouts.Any())
            {
                //no existing linked workouts, so add all workouts
                newFitnessPaths.ToList().ForEach(x => existingWorkout.FitnessPathWorkouts.Add(x));
                await _dbContext.SaveChangesAsync();
                return;
            }
            //workouts which exist in the db, not in the request
            var toRemove = existingWorkout.FitnessPathWorkouts.Where(l2 => !newFitnessPaths.Any(l1 => l1.FitnessPathId == l2.FitnessPathId)).ToList();
            //workouts that exist in the request, not in the db
            var toAdd = newFitnessPaths.Where(l2 => !existingWorkout.FitnessPathWorkouts.Any(l1 => l1.FitnessPathId == l2.FitnessPathId)).ToList();
            toRemove.ForEach(x => existingWorkout.FitnessPathWorkouts.Remove(x));
            toAdd.ForEach(x => existingWorkout.FitnessPathWorkouts.Add(x));
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateMovements(long id, Workout workout)
        {
            var newMovements = workout.WorkoutMovements;
            var existingWorkout = await _dbContext.Workouts.Include(p => p.WorkoutMovements).FirstOrDefaultAsync(u => u.Id == id);
            if (existingWorkout == null)
            {
                //not found, can't update
                return;
            }
            if (!existingWorkout.WorkoutMovements.Any())
            {
                //no existing linked workouts, so add all workouts
                newMovements.ToList().ForEach(x => existingWorkout.WorkoutMovements.Add(x));
                await _dbContext.SaveChangesAsync();
                return;
            }
            //workouts which exist in the db, not in the request
            var toRemove = existingWorkout.WorkoutMovements.Where(l2 => !newMovements.Any(l1 => l1.MovementId == l2.MovementId)).ToList();
            //workouts that exist in the request, not in the db
            var toAdd = newMovements.Where(l2 => !existingWorkout.WorkoutMovements.Any(l1 => l1.MovementId == l2.MovementId)).ToList();
            toRemove.ForEach(x => existingWorkout.WorkoutMovements.Remove(x));
            toAdd.ForEach(x => existingWorkout.WorkoutMovements.Add(x));
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEntity(long id, Workout workout)
        {
            //set relationship property to null so no changes to workotus are made
            workout.FitnessPathWorkouts = null;
            workout.WorkoutMovements = null;
            await base.UpdateExcludeCreated(id, workout);
        }

        public async Task<PagingList<Workout>> SearchWorkouts(PageableQueryRequest request)
        {
            return await PagingList<Workout>.CreateAsync(GetAll()
                .Where(x => x.Tags.Contains(request.Query)), request.Page, request.Size);
        }
    }
}
