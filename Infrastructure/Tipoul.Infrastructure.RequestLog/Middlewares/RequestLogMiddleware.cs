using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tipoul.Infrastructure.RequestLog.DataAccessLayer;
using Tipoul.Infrastructure.RequestLog.Services;

namespace Tipoul.Infrastructure.RequestLog.Middlewares
{
    public class RequestLogMiddleware : IMiddleware
    {
        private readonly RequestLogDbContext dbContext;

        private readonly RequestLogService service;

        public RequestLogMiddleware(RequestLogDbContext dbContext, RequestLogService service)
        {
            this.dbContext = dbContext;
            this.service = service;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            StorageModels.Request request = await AddRequestAsync(context);

            try
            {
                var responseStream = context.Response.Body;

                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;

                    await next.Invoke(context);

                    await SetResponse(context, request, memStream, responseStream);
                }
            }
            catch (Exception exception)
            {
                SetException(request, exception);

                throw;
            }
            finally
            {
                request.Action = context.GetRouteValue("action")?.ToString();
                request.Controller = context.GetRouteValue("controller")?.ToString();

                request.Duration = DateTime.Now - request.CreateDate;

                if (!IsStatus(context))
                    await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SetResponse(HttpContext context, StorageModels.Request request, MemoryStream memStream, Stream responseStream)
        {
            memStream.Position = 0;
            using (var streamReader = new StreamReader(memStream))
            {
                request.Response = new StorageModels.Response
                {
                    ResponseBody = streamReader.ReadToEnd(),
                    ContentType = context.Request.ContentType,
                    StatusCode = context.Response.StatusCode,
                    ResponseHeaders = context.Response.Headers.ToList().ConvertAll(f => new StorageModels.ResponseHeader { Key = f.Key, Value = f.Value }),
                };

                memStream.Position = 0;
                await memStream.CopyToAsync(responseStream);
            }
            request.Success = true;
        }

        private static void SetException(StorageModels.Request request, Exception exception)
        {
            request.Success = false;

            request.RequestException = new StorageModels.RequestException
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace
            };

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;

                request.RequestException.RequestInnerExceptions.Add(new StorageModels.RequestInnerException
                {
                    Message = exception.Message,
                    StackTrace = exception.StackTrace
                });
            }
        }

        private async Task<StorageModels.Request> AddRequestAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            var body = string.Empty;

            if (context.Request.ContentLength.HasValue && context.Request.ContentLength.Value > 0)
            {
                var stream = new StreamReader(context.Request.Body);

                body = await stream.ReadToEndAsync();

                context.Request.Body.Position = 0;
            }

            var request = new StorageModels.Request
            {
                ContentType = context.Request.ContentType,
                IpAddress = context.Connection.RemoteIpAddress.ToString(),
                Method = context.Request.Method,
                Path = context.Request.Path,
                Query = context.Request.QueryString.ToString(),
                RequestBody = new StorageModels.RequestBody { Body = body },
                RequestCookies = context.Request.Cookies.ToList().ConvertAll(f => new StorageModels.RequestCookie { Key = f.Key, Value = f.Value }),
                RequestForms = context.Request.HasFormContentType ? context.Request.Form.ToList().ConvertAll(f => new StorageModels.RequestForm { Key = f.Key, Value = f.Value }) : new List<StorageModels.RequestForm>(),
                RequestHeaders = context.Request.Headers.ToList().ConvertAll(f => new StorageModels.RequestHeader { Key = f.Key, Value = f.Value }),
                RequestQueries = context.Request.Query.ToList().ConvertAll(f => new StorageModels.RequestQuery { Key = f.Key, Value = f.Value }),
            };

            if (!IsStatus(context))
            {
                await dbContext.Requests.AddAsync(request);

                await dbContext.SaveChangesAsync();
            }

            service.SetRequest(request);

            return request;
        }

        private bool IsStatus(HttpContext context)
        {
            return
                context?.Request?.Path.ToString() == "/status"
                ||
                (context?.Request?.Path.ToString() == "/login" && (context?.Request?.Query?.Any(x => x.Value.ToString().EndsWith("/status")) ?? false));
        }
    }
}
