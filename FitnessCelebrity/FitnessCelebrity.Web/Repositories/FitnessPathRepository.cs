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
    public class FitnessPathRepository : BaseRepository<FitnessPath>, IFitnessPathRepository
    {
        private readonly ApplicationDbContext dbContext;
        public FitnessPathRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {
            this.dbContext = dbContext;
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
        public new async Task<FitnessPath> GetById(int id)
        {
            return await GetAll()
                .Include(i => i.FitnessPathWorkouts)
                .Include(i => i.CreatedByUser)
                .ThenInclude(i => i.UserProfile)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<PagingList<FitnessPath>> SearchFitnessPaths(PageableQueryRequest request)
        {
            return await PagingList<FitnessPath>.CreateAsync(GetAll()
                .Where(x => x.Tags.Contains(request.Query)), request.Page, request.Size);
        }
    }
}
