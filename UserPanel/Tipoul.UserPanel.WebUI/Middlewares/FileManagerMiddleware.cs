using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Middlewares
{
    public class FileManagerMiddleware : IMiddleware
    {
        private readonly IConfiguration configuration;

        public FileManagerMiddleware(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.HasValue && File.Exists(configuration["FileManagerPath"] + context.Request.Path.Value))
            {
                using (var stream = new FileStream(configuration["FileManagerPath"] + context.Request.Path.Value, FileMode.Open))
                    await stream.CopyToAsync(context.Response.Body);
            }
            else
                await next.Invoke(context);
        }
    }
}
