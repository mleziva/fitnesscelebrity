using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Services
{
    public class ConfigurationService : IConfigurationService
    {
        //todo create configuration object if required
        public string Url { get => "https://localhost:44362/"; }

        public string GenerateCreatedUrl(string controllerName, long id)
        {
            return $"{Url}/api/{controllerName}{id}";
        }
    }
}
