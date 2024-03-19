using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tipoul.Infrastructure.RequestLog.DataAccessLayer;
using Tipoul.Infrastructure.RequestLog.Middlewares;
using Tipoul.Infrastructure.RequestLog.Services;

namespace Tipoul.Infrastructure.RequestLog.Extentions
{
    public static class RequestLogConfigExtentionMethods
    {
        public static IServiceCollection AddTipoulRequestLog(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            return services
                .AddScoped<RequestLogMiddleware>()
                .AddScoped<RequestLogService>()
                .AddDbContext<RequestLogDbContext>(optionsAction);
        }

        public static IApplicationBuilder UseTipoulRequestLog(this IApplicationBuilder application)
        {
            using (var scope = application.ApplicationServices.CreateScope())
                scope.ServiceProvider.GetService<RequestLogDbContext>().Database.Migrate();

            return application.UseMiddleware<RequestLogMiddleware>();
        }
    }
}
