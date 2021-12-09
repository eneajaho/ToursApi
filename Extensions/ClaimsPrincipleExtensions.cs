using System;
using System.Security.Claims;
using ToursApi.Entities;

namespace ToursApi.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return Convert.ToInt32(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
        
        public static Role GetRole(this ClaimsPrincipal user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var role = user.FindFirst(ClaimTypes.Role)?.Value!;
            
            // Convert String to Enum (all .NET versions)
            return (Role)Enum.Parse(typeof(Role), role);
        }
        
        public static string GetName(this ClaimsPrincipal user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return user.FindFirst(ClaimTypes.Name)?.Value!;
        }
    }
}