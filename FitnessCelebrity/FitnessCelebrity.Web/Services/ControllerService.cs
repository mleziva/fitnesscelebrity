using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Services
{
    /// <summary>
    /// Reduces the number of parameters required in controller constructors by just putting them in here willy nilly
    /// </summary>
    public class ControllerService : IControllerService
    {
        public ControllerService(IMapper mapper, IConfigurationService configurationService)
        {
            Mapper = mapper;
            ConfigurationService = configurationService;
        }
        public IMapper Mapper { get; }
        public IConfigurationService ConfigurationService { get; }
    }
}
