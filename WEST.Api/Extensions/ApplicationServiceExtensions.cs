using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEST.Api.Interfaces;
using WEST.Api.Services;

namespace WEST.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<Data.DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            return services;

        }
    }
}