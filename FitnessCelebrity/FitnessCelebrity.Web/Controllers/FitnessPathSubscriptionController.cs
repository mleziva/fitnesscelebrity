using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCelebrity.Web.Extensions;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessPathSubscriptionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IFitnessPathSubscriptionRepository repository;
        public FitnessPathSubscriptionController(IFitnessPathSubscriptionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]long fitnessPathId)
        {
            //todo return path to get users subscriptions or get fp subscriptions?
            //add created date
            var userId = User.Identity.GetId();
            var fitness = new FitnessPathSubscription() { FitnessPathId = fitnessPathId, ApplicationUserId = userId };
            var insertedFp = await repository.Create(fitness);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await repository.Delete(id);
            return Ok();
        }
    }
}