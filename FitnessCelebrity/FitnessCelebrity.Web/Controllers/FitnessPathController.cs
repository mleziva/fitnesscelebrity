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

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessPathController : ControllerBase
    {
        private const string controllerName = "FitnessPath";
        private readonly IConfigurationService configService;
        private readonly IMapper mapper;
        private readonly IFitnessPathRepository fitnessPathRepository;
        public FitnessPathController(IFitnessPathRepository fitnessPathRepository, IControllerService controllerService)
        {
            this.fitnessPathRepository = fitnessPathRepository;
            this.configService = controllerService.ConfigurationService;
            this.mapper = controllerService.Mapper;
        }
        /// <summary>
        /// If user id is not supplied, returns paths of current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<FitnessPath>> Get([FromQuery(Name = "")]PageableUserIdRequest request)
        {
            if (request.UserId == null) request.UserId = User.Identity.GetId();
            var paths = await fitnessPathRepository.ListUserCreatedFitnessPaths(request);
            return paths;
        }
        // GET: api/FitnessPath/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessPath>> GetAsync(int id)
        {
            var path = await fitnessPathRepository.GetById(id);
            if (path == null)
                return NotFound();

            var fitnessPath = mapper.Map<DtoFitnessPath>(path);
            return Ok(fitnessPath);
        }
        [Route("{id}/subscribers")]
        [HttpGet]
        public async Task<IEnumerable<UserProfile>> GetSubscribedUsers(long id, [FromQuery(Name = "")]PageableIdRequest request)
        {
            request.Id = id;
            var users = await fitnessPathRepository.GetSubscribedUsers(request);
            return users;
        }
        [Route("subscription/{userId}")]
        [HttpGet]
        public async Task<IEnumerable<FitnessPath>> GetSubscribedPaths(string userId, [FromQuery(Name = "")]PageableUserIdRequest request)
        {
            request.UserId = userId;
            var paths = await fitnessPathRepository.GetSubscribedPaths(request);
            return paths;
        }
        // POST: api/FitnessPath
        [HttpPost]
        public async Task<ActionResult> Post(FitnessPath fitnessPath)
        {
            var createdFitnessPath = await fitnessPathRepository.Create(fitnessPath);
            return Created(configService.GenerateCreatedUrl(controllerName, createdFitnessPath.Id), createdFitnessPath);
        }

        // PUT: api/FitnessPath/5
        [HttpPut("{id}")]
        public async Task Put(long id, DtoFitnessPath fitnessPath)
        {
            var path = mapper.Map<FitnessPath>(fitnessPath, opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            await fitnessPathRepository.UpdateEntity(id, path);
        }
        [HttpPut("workouts/{id}")]
        public async Task UpdateWorkouts(long id, DtoFitnessPath fitnessPath)
        {
            var path = mapper.Map<FitnessPath>(fitnessPath, opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            await fitnessPathRepository.UpdateWorkouts(id, path);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //todo add deleted timestamp
        }

        [Route("search")]
        [HttpGet]
        public async Task<IEnumerable<FitnessPath>> Search([FromQuery(Name = "")]PageableQueryRequest request)
        {
            var paths = await fitnessPathRepository.SearchFitnessPaths(request);
            return paths;
        }
    }
}
