using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class FitnessPathRepository : BaseRepository<FitnessPath>, IFitnessPathRepository
    {
        public FitnessPathRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {
        }

        public async Task<PagingList<FitnessPath>> ListUserCreatedFitnessPaths(PageableUserIdRequest request)
        {
            return await PagingList<FitnessPath>.CreateAsync(GetAll().Where(x => x.CreatedById == request.UserId), request.Page, request.Size);
        }
        /// <summary>
        /// Get selected fitness path and its included workouts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public new async Task<FitnessPath> GetById(long id)
        {
            return await GetAll()
                .Include(i => i.FitnessPathWorkouts)
                .ThenInclude(i=>i.Workout)
                .Include(i => i.CreatedByUser.UserProfile)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<PagingList<FitnessPath>> SearchFitnessPaths(PageableQueryRequest request)
        {
            return await PagingList<FitnessPath>.CreateAsync(GetAll()
                .Where(x => x.Tags.Contains(request.Query)), request.Page, request.Size);
        }

        public async Task<PagingList<UserProfile>> GetSubscribedUsers(PageableIdRequest request)
        {
            //todo maybe move this?
            var dbset = GetSet<UserProfile>()
                .Where(x => x.ApplicationUser.FitnessPathSubscriptions.Any(f => f.FitnessPathId == request.Id));
            return await PagingList<UserProfile>.CreateAsync(dbset, request.Page, request.Size);
        }

        public async Task<PagingList<FitnessPath>> GetSubscribedPaths(PageableUserIdRequest request)
        {
            var dbset = GetAll()
               .Where(x => x.Subscriptions.Any(f => f.ApplicationUserId == request.UserId));
            return await PagingList<FitnessPath>.CreateAsync(dbset, request.Page, request.Size);
        }

        new public async Task Update(long id, FitnessPath fitnessPath)
        {
            var existingFitnessPath = await _dbContext.FitnessPaths.Include(p => p.FitnessPathWorkouts).FirstOrDefaultAsync(u => u.Id == id);
            if (existingFitnessPath == null)
            {
                return;
            }
            if (!existingFitnessPath.FitnessPathWorkouts.Any())
            {
                _dbContext.FitnessPaths.Update(fitnessPath);
                await _dbContext.SaveChangesAsync();
                return;
            }
            //add and remove workouts to match model
            var newWorkouts = fitnessPath.FitnessPathWorkouts;
            var toRemove = existingFitnessPath.FitnessPathWorkouts.Where(l2 =>!newWorkouts.Any(l1 => l1.WorkoutId == l2.WorkoutId)).ToList();
            var toAdd = newWorkouts.Where(l2 => !existingFitnessPath.FitnessPathWorkouts.Any(l1 => l1.WorkoutId == l2.WorkoutId)).ToList();
            toRemove.ForEach(x => existingFitnessPath.FitnessPathWorkouts.Remove(x));
            toAdd.ForEach(x => existingFitnessPath.FitnessPathWorkouts.Add(x));
            await _dbContext.SaveChangesAsync();
            _dbContext.Entry(existingFitnessPath).State = EntityState.Detached;

            fitnessPath.FitnessPathWorkouts.Clear();
            _dbContext.FitnessPaths.Update(fitnessPath);
            await _dbContext.SaveChangesAsync();
        }
    }
}
