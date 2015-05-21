using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Common.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetClaim(this IIdentity identity, string claim)
        {
            var id = ((System.Security.Claims.ClaimsIdentity)identity).Claims;
            var role = id.Where(c => c.Type.Equals(claim)).First().Value;
            return role;
        }
        public static int GetIdClaim(this IIdentity identity, string claim)
        {
            var id = ((System.Security.Claims.ClaimsIdentity)identity).Claims;
            var role = id.Where(c => c.Type.Equals(claim)).First().Value;
            return Int32.Parse(role);
        }
    }
}