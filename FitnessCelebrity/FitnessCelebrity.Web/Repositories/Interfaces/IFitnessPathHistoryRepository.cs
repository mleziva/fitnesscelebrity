using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Dto.FitnessPathHistory;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public interface IFitnessPathHistoryRepository : IBaseRepository<FitnessPathHistory>
    {
        Task<PagingList<FitnessPathHistory>> Get(FitnessPathHistoryGetAllRequest request);
        Task<FitnessPathHistory> GetFullEntityById(long id);
    }   
}
