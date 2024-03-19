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

using Tipoul.AdminPanel.WebUI.Middlewares;
using Tipoul.Athentication.Agent;
using Tipoul.Athentication.Agent.Middlewares;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.ShahinService.DataAccessLayer;
using Tipoul.Framework.ShahinService.ShahinOperation;
using Tipoul.Infrastructure.RequestLog.Extentions;

namespace Tipoul.AdminPanel.WebUI
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
            //services.AddDbContext<TipoulShahinDbContext>(options =>
            //{
            //    var conBuilder = new IghanConnectionStringBuilder(
            //        Configuration["dbShahinOptions:instance"],
            //        Configuration["dbShahinOptions:dbName"],
            //        Configuration["dbShahinOptions:userName"],
            //        Configuration["dbShahinOptions:password"]);

            //    options.UseSqlServer(conBuilder.Build());
            //});

            services.AddTipoulRequestLog(options =>
            {
                var conBuilder = new IghanConnectionStringBuilder(
                    Configuration["logDbOptions:instance"],
                    Configuration["logDbOptions:dbName"],
                    Configuration["logDbOptions:userName"],
                    Configuration["logDbOptions:password"]);

                options.UseSqlServer(conBuilder.Build());
            });
            //services.AddScoped<ShahinService>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTipoulAthentication();

            services.AddSession();

            services.AddTransient<FileManagerMiddleware>();

            services.AddControllersWithViews()
                 .AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseTipoulRequestLog();

            app.UseStaticFiles();

            app.UseMiddleware<FileManagerMiddleware>();

            app.UseRouting();

            app.UseSession();

            using (var scope = app.ApplicationServices.CreateScope())
                scope.ServiceProvider.GetRequiredService<TipoulFrameworkDbContext>().Database.Migrate();

            app.AddTipoulAthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
