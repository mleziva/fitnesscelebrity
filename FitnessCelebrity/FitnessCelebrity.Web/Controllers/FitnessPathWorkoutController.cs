using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCelebrity.Web.Dto.FitnessPathWorkout;
using FitnessCelebrity.Web.Extensions;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Repositories;
using FitnessCelebrity.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessPathWorkoutController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IFPWorkoutRepository repository;
        public FitnessPathWorkoutController(IFPWorkoutRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //api/fitnesspath/6/workouts
        [HttpPut("fitnessPath/{id}/workouts")]
        public async Task<ActionResult> Put(long id, [FromBody]IList<DtoFitnessPathWorkout> fitnessPathWorkouts)
        {
            //todo return path to get users subscriptions or get fp subscriptions?
            //add created date
            var userId = User.Identity.GetId();
            var workouts = mapper.Map< IList<FitnessPathWorkout>>(fitnessPathWorkouts, opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            await repository.UpdateWorkouts(id, workouts);
            return Ok();
        }
    }
}