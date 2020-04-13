using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public interface IFitnessPathRepository : IBaseRepository<FitnessPath>
    {
        Task<PagingList<FitnessPath>> ListUserCreatedFitnessPaths(PageableUserIdRequest request);
        Task<PagingList<FitnessPath>> SearchFitnessPaths(PageableQueryRequest request);
    }
}
