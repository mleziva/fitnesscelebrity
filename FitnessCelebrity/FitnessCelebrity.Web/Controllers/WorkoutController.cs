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
        private readonly IWorkoutRepository workoutRepository;
        public WorkoutController(IWorkoutRepository workoutRepository, IControllerService controllerService)
        {
            this.workoutRepository = workoutRepository;
            mapper = controllerService.Mapper;
            configService = controllerService.ConfigurationService;
        }
        // GET: api/Workout
        [HttpGet]
        public async Task<IEnumerable<Workout>> Get()
        {
            return await workoutRepository.GetAll().ToListAsync();
        }

        // GET: api/Workout/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var workout = await workoutRepository.GetById(id);
            if (workout == null)
                return NotFound();

            return Ok(workout);
        }

        // POST: api/Workout
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] WorkoutDtoCreate workout)
        {
            var workoutEntity = mapper.Map<Workout>(workout, opt => {opt.Items["UserId"] = User.Identity.GetId(); });
            var createdWorkout = await workoutRepository.Create(workoutEntity);
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
    }
}
