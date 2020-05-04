using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Dto.FitnessPathHistory;
using FitnessCelebrity.Web.Dto.WorkoutHistory;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public interface IWorkoutHistoryRepository : IBaseRepository<WorkoutHistory>
    {
        Task<PagingList<WorkoutHistory>> Get(WorkoutHistoryGetAllRequest request);
    }   
}
