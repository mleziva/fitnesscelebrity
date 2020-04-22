using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCelebrity.Web.Dto.Movement;
using FitnessCelebrity.Web.Extensions;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using FitnessCelebrity.Web.Repositories.Interfaces;
using FitnessCelebrity.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly string controllerName = "Movement";
        private readonly IMapper mapper;
        private readonly IConfigurationService configService;
        private readonly IMovementRepository repository;
        public MovementController(IMovementRepository repository, IControllerService controllerService)
        {
            this.repository = repository;
            this.mapper = controllerService.Mapper;
            configService = controllerService.ConfigurationService;
        }
        /// <summary>
        /// If user id is not supplied, returns paths of current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Movement>> Get([FromQuery(Name = "")]PageableUserIdRequest request)
        {
            var movements = await repository.Get(request);
            return movements;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var movement = await repository.GetById(id);
            if (movement == null)
                return NotFound();

            return Ok(movement);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovementDtoCreate movement)
        {
            var movementEntity = mapper.Map<Movement>(movement, opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            var createdMovement = await repository.Create(movementEntity);
            return Created(configService.GenerateCreatedUrl(controllerName, createdMovement.Id), createdMovement);
        }

        [HttpPut("{id}")]
        public async Task Put(long id, MovementDtoCreate movement)
        {
            var movementEntity = mapper.Map<Movement>(movement, opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            await repository.UpdateEntity(id, movementEntity);
        }
        [HttpPut("{id}/workouts")]
        public async Task UpdateWorkouts(long id, MovementDtoCreate movement)
        {
            var movementEntity = mapper.Map<Movement>(movement, opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            await repository.UpdateWorkouts(id, movementEntity);
        }

        [Route("search")]
        [HttpGet]
        public async Task<IEnumerable<Movement>> Search([FromQuery(Name = "")]PageableQueryRequest request)
        {
            var movements = await repository.Search(request);
            return movements;
        }
    }
}