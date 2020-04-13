using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Services
{
    public interface IConfigurationService
    {
        public string Url { get; }
        public string GenerateCreatedUrl(string controllerName, long id);
    }
}
