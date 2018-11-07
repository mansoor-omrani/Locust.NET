using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class SecurityExtensions
    {
        public static string GetRoleName(this IIdentity identity)
        {
            var result = null as string;
            var claimUser = identity as ClaimsIdentity;
            
            if (claimUser != null)
            {
                var claims = claimUser.Claims;

                if (claims != null && claims.Count() > 0)
                {
                    var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                    if (roleClaim != null)
                    {
                        result = roleClaim.Value;
                    }
                }
            }

            return result;
        }
        public static string GetRoleNames(this IIdentity identity)
        {
            var result = null as string;
            var claimUser = identity as ClaimsIdentity;

            if (claimUser != null)
            {
                var claims = claimUser.Claims;

                if (claims != null && claims.Count() > 0)
                {
                    return claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList()?.Join(',');
                }
            }

            return result;
        }
    }
}
