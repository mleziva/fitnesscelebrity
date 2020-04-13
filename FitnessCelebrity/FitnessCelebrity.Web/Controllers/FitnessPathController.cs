using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCelebrity.Web.Extensions;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using FitnessCelebrity.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessPathController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IFitnessPathRepository fitnessPathRepository;
        public FitnessPathController(IFitnessPathRepository fitnessPathRepository, IMapper mapper)
        {
            this.fitnessPathRepository = fitnessPathRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Only the names of fitness paths returned for user
        /// If user id is not supplied, returns paths of current user
        /// </summary>
        /// <returns></returns>
        [Route("user/list")]
        [HttpGet]
        public async Task<IEnumerable<FitnessPath>> Get([FromQuery(Name ="")]PageableUserIdRequest request)
        {
            if (request.UserId == null) request.UserId = User.Identity.GetId();
            var paths = await fitnessPathRepository.ListUserCreatedFitnessPaths(request);
            return paths;
        }
        // GET: api/FitnessPath
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FitnessPath/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessPathDtoGet>> GetAsync(int id)
        {
            var path = await fitnessPathRepository.GetById(id);
            if (path == null)
                return NotFound();

            var fitnessPath = mapper.Map<FitnessPathDtoGet>(path);
            return Ok(fitnessPath);
        }

        // POST: api/FitnessPath
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FitnessPath/5
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
