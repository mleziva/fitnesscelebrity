using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserProfile> GetByUserName(string userName)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
