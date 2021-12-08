using System;
using System.Security.Claims;

namespace ToursApi.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return Convert.ToInt32(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
        
        public static string GetName(this ClaimsPrincipal user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return user.FindFirst(ClaimTypes.Name)?.Value!;
        }
    }
}