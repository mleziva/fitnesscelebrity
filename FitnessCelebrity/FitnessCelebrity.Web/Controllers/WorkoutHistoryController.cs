using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Dto.WorkoutHistory;
using FitnessCelebrity.Web.Extensions;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Repositories;
using FitnessCelebrity.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutHistoryController : ControllerBase
    {
        private const string controllerName = "WorkoutHistory";
        private readonly IConfigurationService configService;
        private readonly IMapper mapper;
        private readonly IWorkoutHistoryRepository repository;
        public WorkoutHistoryController(IWorkoutHistoryRepository repository, IControllerService controllerService)
        {
            this.repository = repository;
            this.configService = controllerService.ConfigurationService;
            this.mapper = controllerService.Mapper;
        }
        [HttpGet]
        public async Task<ActionResult<PagingList<WorkoutHistory>>> Get([FromQuery(Name = "")]WorkoutHistoryGetAllRequest request)
        {
            var results = await repository.Get(request);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutHistory>> Get(long id)
        {
            var result = await repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(DtoWorkoutHistory workoutHistory)
        {
            var wh = mapper.Map<WorkoutHistory>(workoutHistory, opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            var created = await repository.Create(wh);
            return Created(configService.GenerateCreatedUrl(controllerName, created.Id), created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DtoWorkoutHistory workoutHistory)
        {
            var wh = mapper.Map<WorkoutHistory>(workoutHistory, opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            await repository.Update(id, wh);
            return Ok();
        }
    }
}