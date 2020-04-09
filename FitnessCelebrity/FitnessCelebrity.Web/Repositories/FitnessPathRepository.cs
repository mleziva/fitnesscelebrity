using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
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

        public async Task<PagingList<FitnessPath>> ListUserCreatedFitnessPaths(PageableUserIdRequest request)
        {
            return await PagingList<FitnessPath>.CreateAsync(GetAll().Where(x => x.CreatedById == request.UserId), request.Page, request.Size);
        }
    }
}
