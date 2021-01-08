using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace WorkoutTracker.API.Data
{
    public static class UserExtensionMethods
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            var id = from c in user.Claims
                     where c.Type.Contains("nameidentifier")
                     select c.Value;

            return id.First().ToString();
        } 
    }
}
