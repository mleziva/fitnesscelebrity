using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutRepository workoutRepository;
        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            this.workoutRepository = workoutRepository;
        }
        // GET: api/Workout
        [HttpGet]
        public async Task<IEnumerable<Workout>> Get()
        {
            return await workoutRepository.GetAll().ToListAsync();
        }

        // GET: api/Workout/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Workout
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Workout workout)
        {
            await workoutRepository.Create(workout);
            return Ok();
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
