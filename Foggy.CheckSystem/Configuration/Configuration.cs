using Foggy.CheckSystem.Checkers;
using Foggy.CheckSystem.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.CheckSystem.Configuration
{
    public static class Configuration
    {
        public static void ConfigureCheckerSystem(this IServiceCollection services)
        {
            services.AddScoped<IChecker, AnilibriaChecker>();
        }
    }
}
