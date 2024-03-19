using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Middlewares;
using Tipoul.Athentication.Agent.Services;

namespace Tipoul.Athentication.Agent
{
    public static class ExtentionMethods
    {
        public static void AddTipoulAthentication(this IServiceCollection services)
        {
            services.AddSingleton<AthenticationProvider>();
            services.AddSingleton<AthenticationMiddleware>();
        }

        public static void AddTipoulAthentication(this IApplicationBuilder app)
        {
            app.UseMiddleware<AthenticationMiddleware>();
        }
    }
}
