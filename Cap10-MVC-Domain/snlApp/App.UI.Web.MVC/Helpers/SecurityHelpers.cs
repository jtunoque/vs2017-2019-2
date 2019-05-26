using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace App.UI.Web.MVC.Helpers
{
    public class SecurityHelpers
    {
        private static IEnumerable<Claim> GetClaimsByType(string type)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claims = identity.Claims.Where(item => item.Type == type).ToList();

            return claims;
        }

        public static string GetUserFullName()
        {
            var claimValue =
                GetClaimsByType("NombreCompleto")
                .FirstOrDefault()?.Value;

            return claimValue;
        }

        public static bool IsSupervisor()
        {
            return HttpContext.Current.User.IsInRole("supervisor");
        }

        public static bool IsOperator()
        {
            return HttpContext.Current.User.IsInRole("operador");
        }

        public static bool IsAdmin()
        {
            return HttpContext.Current.User.IsInRole("admin");
        }
    }
}