using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Dto.FitnessPathHistory;
using FitnessCelebrity.Web.Dto.WorkoutHistory;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class WorkoutHistoryRepository : BaseRepository<WorkoutHistory>, IWorkoutHistoryRepository
    {
        public WorkoutHistoryRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {
        }

        public async Task<PagingList<WorkoutHistory>> Get(WorkoutHistoryGetAllRequest request)
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
            return await PagingList<WorkoutHistory>.CreateAsync(query, request.Page, request.Size);
        }
    }
}
