using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories.Interfaces
{
    public interface IMovementRepository : IBaseRepository<Movement>
    {
        Task<PagingList<Movement>> Get(PageableUserIdRequest request);
    }
}
