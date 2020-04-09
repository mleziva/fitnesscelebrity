using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class FitnessPathRepository : BaseRepository<FitnessPath>, IFitnessPathRepository
    {
        public FitnessPathRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {

        }

        public async Task<IEnumerable<FitnessPath>> ListUserCreatedFitnessPaths(string userId)
        {
            return await GetAll().Where(x => x.CreatedById == userId).ToListAsync();
        }
    }
}
