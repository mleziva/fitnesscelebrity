using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCelebrity.Web.Extensions;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto.UserProfile;
using FitnessCelebrity.Web.Repositories;
using FitnessCelebrity.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace FitnessCelebrity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private const string controllerName = "userprofile";
        private readonly IMapper mapper;
        private readonly IConfigurationService configService;
        private readonly IUserProfileRepository userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository, IControllerService controllerService)
        {
            this.userProfileRepository = userProfileRepository;
            mapper = controllerService.Mapper;
            configService = controllerService.ConfigurationService;
        }
        // GET: api/UserProfile
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserProfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> Get(int id)
        {
            var profile = await userProfileRepository.GetById(id);
            if (profile == null)
                return NotFound();
            return Ok(profile);
        }
        // GET: api/UserProfile/username/name
        [Route("username/{userName}")]
        [HttpGet]
        public async Task<ActionResult<UserProfile>> GetByUserName(string userName)
        {
            var profile = await userProfileRepository.GetByUserName(userName);
            if (profile == null)
                return NotFound();
            return Ok(profile);
        }
        // POST: api/UserProfile
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] DtoCreateUserProfile userProfile)
        {
            //todo make sure username is not taken since that must be unique
            var userProfileEntity = mapper.Map<UserProfile>(userProfile,  opt => { opt.Items["UserId"] = User.Identity.GetId(); });
            userProfileEntity = await userProfileRepository.Create(userProfileEntity);
            return Created(configService.GenerateCreatedUrl(controllerName, userProfileEntity.Id), userProfileEntity);
        }

        // PUT: api/UserProfile/5
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
