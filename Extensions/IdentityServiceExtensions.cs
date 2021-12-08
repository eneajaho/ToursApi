using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ToursApi.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(config.GetSection("Jwt:Key").Value));
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // ValidateIssuer = true,
                        // ValidateAudience = true,
                        // ValidIssuer = config.GetSection("Jwt:Issuer").Value,  
                        // ValidAudience = config.GetSection("Jwt:Audience").Value, 
                        IssuerSigningKey = securityKey
                    };
                });

            return services;
        }
    }
}