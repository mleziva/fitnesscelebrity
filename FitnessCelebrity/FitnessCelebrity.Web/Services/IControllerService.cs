using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Services
{
    public interface IControllerService
    {
        public IMapper Mapper { get; }
        public IConfigurationService ConfigurationService { get; }
    }
}
