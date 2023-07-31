using Foggy.DataProvider.Configuration;
using Foggy.Logic.Interfaces;
using Foggy.Logic.Services;
using Foggy.NotificationSystem.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foggy.Logic.Configuration
{
    public static class Configuration
    {
        public static void ConfigureLogicLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDataProviderLayer(configuration);
            services.ConfigureNotificationSystem();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IToRememberService, ToRememberService>();
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
