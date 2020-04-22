using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using FitnessCelebrity.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class MovementRepository : BaseRepository<Movement>, IMovementRepository
    {
        public MovementRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {

        }
        public async Task<PagingList<Movement>> Get(PageableUserIdRequest request)
        {
            return await PagingList<Movement>.CreateAsync(GetAll().Where(x => x.CreatedById == request.UserId), request.Page, request.Size);
        }
        public async Task<PagingList<Movement>> Search(PageableQueryRequest request)
        {
            return await PagingList<Movement>.CreateAsync(GetAll()
                .Where(x => x.Tags.Contains(request.Query)), request.Page, request.Size);
        }

        public async Task UpdateWorkouts(long id, Movement movement)
        {
            var newWorkouts = movement.WorkoutMovements;
            var existingMovement = await _dbContext.Movements.Include(p => p.WorkoutMovements).FirstOrDefaultAsync(u => u.Id == id);
            if (existingMovement == null)
            {
                //not found, can't update
                return;
            }
            if (!existingMovement.WorkoutMovements.Any())
            {
                //no existing linked workouts, so add all workouts
                newWorkouts.ToList().ForEach(x => existingMovement.WorkoutMovements.Add(x));
                await _dbContext.SaveChangesAsync();
                return;
            }
            //workouts which exist in the db, not in the request
            var toRemove = existingMovement.WorkoutMovements.Where(l2 => !newWorkouts.Any(l1 => l1.WorkoutId == l2.WorkoutId)).ToList();
            //workouts that exist in the request, not in the db
            var toAdd = newWorkouts.Where(l2 => !existingMovement.WorkoutMovements.Any(l1 => l1.WorkoutId == l2.WorkoutId)).ToList();
            toRemove.ForEach(x => existingMovement.WorkoutMovements.Remove(x));
            toAdd.ForEach(x => existingMovement.WorkoutMovements.Add(x));
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEntity(long id, Movement movement)
        {
            //set relationship property to null so no changes to workotus are made
            movement.WorkoutMovements = null;
            await base.UpdateExcludeCreated(id, movement);
        }
    }
}
