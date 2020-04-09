using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Extensions
{
    public static class IdentityExtension
    {
        /// <summary>
        /// Return claim that matches URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return claim.Value;
        }
    }
}
