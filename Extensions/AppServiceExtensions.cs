using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToursApi.Entities;
using ToursApi.Interfaces;
using ToursApi.Repository;
using ToursApi.Services;

namespace ToursApi.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlite(
                config.GetConnectionString("DefaultConnection"))
            );
            
            services.AddScoped<ITokenService, TokenService>();
            // services.AddScoped<IPhotoService, PhotoService>();
            //
            services.AddScoped<UserService>();
            services.AddScoped<PackageService>();
            // services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            //
            // services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            //
            // services.AddScoped<LogUserActivity>();

            return services;
        }

    }
}
