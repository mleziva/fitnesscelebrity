using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using FitnessCelebrity.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMovementRepository repository;
        public MovementController(IMovementRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
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
        [Route("search")]
        [HttpGet]
        public async Task<IEnumerable<Movement>> Search([FromQuery(Name = "")]PageableQueryRequest request)
        {
            var movements = await repository.Search(request);
            return movements;
        }
    }
}