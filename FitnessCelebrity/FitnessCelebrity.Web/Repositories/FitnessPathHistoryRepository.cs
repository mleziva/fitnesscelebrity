using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Dto.FitnessPathHistory;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class FitnessPathHistoryRepository : BaseRepository<FitnessPathHistory>, IFitnessPathHistoryRepository
    {
        public FitnessPathHistoryRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {
        }

        public async Task<PagingList<FitnessPathHistory>> Get(FitnessPathHistoryGetAllRequest request)
        {
            var query = GetAll();
            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = query.Where(i => i.UserId == request.UserId);
            }
            if (request.State != null)
            {
                query = query.Where(i => i.State == request.State);
            }
            return await PagingList<FitnessPathHistory>.CreateAsync(query, request.Page, request.Size);
        }
    }
}
