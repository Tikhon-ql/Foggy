using Foggy.Common.Interfaces;
using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foggy.DataProvider.Configuration
{
    public static class Configuration
    {
        public static void ConfigureDataProviderLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("FoggyConnectionString");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddScoped<IToRememberRepository, ToRememberRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
        }
    }
}
