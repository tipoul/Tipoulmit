using Ighan.DbHelpers.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Infrastructure.RequestLog.DataAccessLayer;
using Tipoul.Infrastructure.RequestLog.Extentions;
using Tipoul.PersonalGateWay.WebUI.Middlewares;
using Tipoul.Services.Agent;

namespace Tipoul.PersonalGateWay.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TipoulFrameworkDbContext>(options =>
            {
                var conBuilder = new IghanConnectionStringBuilder(
                    Configuration["dbOptions:instance"],
                    Configuration["dbOptions:dbName"],
                    Configuration["dbOptions:userName"],
                    Configuration["dbOptions:password"]);

                options.UseSqlServer(conBuilder.Build());
            });

            services.AddTipoulRequestLog(options =>
            {
                var conBuilder = new IghanConnectionStringBuilder(
                    Configuration["logDbOptions:instance"],
                    Configuration["logDbOptions:dbName"],
                    Configuration["logDbOptions:userName"],
                    Configuration["logDbOptions:password"]);

                options.UseSqlServer(conBuilder.Build());
            });

            services.AddTransient<FileManagerMiddleware>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ResponseUtilities>();
            services.AddScoped<GateWayService>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseTipoulRequestLog();

            app.UseStaticFiles();

            app.UseMiddleware<FileManagerMiddleware>();

            app.UseRouting();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<TipoulFrameworkDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<RequestLogDbContext>().Database.Migrate();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
