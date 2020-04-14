using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public class FitnessPathSubscriptionRepository : BaseRepository<FitnessPathSubscription>, IFitnessPathSubscriptionRepository
    {
        public FitnessPathSubscriptionRepository(ApplicationDbContext dbContext)
: base(dbContext)
        {

        }
    }
}
