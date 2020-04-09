using FitnessCelebrity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public interface IFitnessPathRepository : IBaseRepository<FitnessPath>
    {
        Task<IEnumerable<FitnessPath>> ListUserCreatedFitnessPaths(string userId);
    }
}
