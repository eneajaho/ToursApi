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

            services
                .AddAuthentication(auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = config.GetSection("Jwt:Issuer").Value,
                        ValidateAudience = true,
                        ValidAudience = config.GetSection("Jwt:Audience").Value,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = securityKey
                    };
                });

            return services;
        }
    }
}