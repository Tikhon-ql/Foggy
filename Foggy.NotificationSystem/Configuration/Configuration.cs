using Foggy.NotificationSystem.Interfaces;
using Foggy.NotificationSystem.Senders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.NotificationSystem.Configuration
{
    public static class Configuration
    {
        public static void ConfigureNotificationSystem(this IServiceCollection services)
        {
            services.AddScoped<ISender, TelegramSender>();
        }
    }
}
