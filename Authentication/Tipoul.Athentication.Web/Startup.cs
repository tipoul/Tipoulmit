using Ighan.DbHelpers.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Infrastructure.RequestLog.Extentions;

namespace Tipoul.Athentication.Web
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
                    Configuration["dbOptions:user"],
                    Configuration["dbOptions:pass"]);

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

            services.AddScoped<Services.SMSDotIrSMSService>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseTipoulRequestLog();

            using (var scope = app.ApplicationServices.CreateScope())
                scope.ServiceProvider.GetService<TipoulFrameworkDbContext>().Database.Migrate();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
