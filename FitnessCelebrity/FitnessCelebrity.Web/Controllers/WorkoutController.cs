using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCelebrity.Web.Extensions;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using FitnessCelebrity.Web.Repositories;
using FitnessCelebrity.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly string controllerName = "workout";
        private readonly IMapper mapper;
        private readonly IConfigurationService configService;
        private readonly IWorkoutRepository repository;
        public WorkoutController(IWorkoutRepository repository, IControllerService controllerService)
        {
            this.repository = repository;
            mapper = controllerService.Mapper;
            configService = controllerService.ConfigurationService;
        }
        // GET: api/Workout
        [HttpGet]
        public async Task<IEnumerable<Workout>> Get([FromQuery(Name = "")]PageableUserIdRequest request)
        {
            var workouts = await repository.Get(request);
            return workouts;
        }

        // GET: api/Workout/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var workout = await repository.GetById(id);
            if (workout == null)
                return NotFound();

            return Ok(workout);
        }

        // POST: api/Workout
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] WorkoutDtoCreate workout)
        {
            var workoutEntity = mapper.Map<Workout>(workout, opt => {opt.Items["UserId"] = User.Identity.GetId(); });
            var createdWorkout = await repository.Create(workoutEntity);
            return Created(configService.GenerateCreatedUrl(controllerName, createdWorkout.Id), createdWorkout);
        }

        // PUT: api/Workout/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("search")]
        [HttpGet]
        public async Task<IEnumerable<Workout>> Search([FromQuery(Name = "")]PageableQueryRequest request)
        {
            var workouts = await repository.SearchWorkouts(request);
            return workouts;
        }
    }
}
