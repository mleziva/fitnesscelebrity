using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using FitnessCelebrity.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class MovementRepository : BaseRepository<Movement>, IMovementRepository
    {
        public MovementRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {

        }
        public async Task<PagingList<Movement>> Get(PageableUserIdRequest request)
        {
            return await PagingList<Movement>.CreateAsync(GetAll().Where(x => x.CreatedById == request.UserId), request.Page, request.Size);
        }
        public async Task<PagingList<Movement>> Search(PageableQueryRequest request)
        {
            return await PagingList<Movement>.CreateAsync(GetAll()
                .Where(x => x.Tags.Contains(request.Query)), request.Page, request.Size);
        }
    }
}
