using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Tipoul.Framework.Services.RequestLog.DataAccessLayer;
using Tipoul.Framework.Services.RequestLog.StorageModels.ShaparakTax;
using Tipoul.Framework.Services.ShaparakTax.Models;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.Framework.Services.ShaparakTax
{
    public class ShaparakTaxService
    {
        private readonly IConfiguration configuration;

        private readonly RequestLogDbContext dbContext;

        private readonly RequestLogUtility<RequestLog.StorageModels.ShaparakTax.ShaparakTaxRequest> requestLogUtility;

        public ShaparakTaxService(IConfiguration configuration, RequestLogDbContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            requestLogUtility = new RequestLogUtility<RequestLog.StorageModels.ShaparakTax.ShaparakTaxRequest>()
                .Catch(CatchLogException)
                .Finally(async requestLog =>
                {
                    requestLog.Duration = DateTime.Now - requestLog.CreateDate;

                    await dbContext.SaveChangesAsync();
                });
        }

        private Task CatchLogException(ShaparakTaxRequest requestLog, Exception exception)
        {
            requestLog.Success = false;
            requestLog.ShaparakTaxRequestException = new ShaparakTaxRequestException
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace
            };

            return Task.CompletedTask;
        }

        public async Task<GetStatusResult?> GetStatusAsync(GetStatusModel model, string? extraParameterForlog, int userId)
        {
            var url = "webService/tax/api/inquiry";

            var requestLog = new ShaparakTaxRequest
            {
                ExtraParameter = extraParameterForlog,
                UserId = userId,
                URL = url,
                TrackingCode = model.TrackingNumber,
                Body = JsonSerializer.Serialize(model)
            };

            dbContext.ShaparakTaxRequests.Add(requestLog);

            await dbContext.SaveChangesAsync();

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var client = GetHttpClient(requestLog))
                {
                    var postResult = await client.PostCamelCaseStringContentAsync<GetStatusResult>(url, model);

                    requestLog.Body = postResult.ModelString;
                    requestLog.Response = postResult.ResponseString;

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    postResult.Result.ServiceLogId = requestLog.Id;

                    return postResult.Result;
                }
            });
        }

        public async Task<RegisterResult?> RegisterAsync(RegisterModel model, string? extraParameterForlog, int userId)
        {
            var url = "webService/tax/api/register";

            var requestLog = new ShaparakTaxRequest
            {
                ExtraParameter = extraParameterForlog,
                UserId = userId,
                URL = url,
                TrackingCode = model.TaxpayerInfo.TrackingNumber,
                Body = JsonSerializer.Serialize(model)
            };

            dbContext.ShaparakTaxRequests.Add(requestLog);

            await dbContext.SaveChangesAsync();

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var client = GetHttpClient(requestLog))
                {
                    var postResult = await client.PostCamelCaseStringContentAsync<RegisterResult>(url, model);

                    requestLog.Body = postResult.ModelString;
                    requestLog.Response = postResult.ResponseString;

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    postResult.Result.ServiceLogId = requestLog.Id;

                    return postResult.Result;
                }
            });
        }

        private HttpClient GetHttpClient(ShaparakTaxRequest requestLog)
        {
            var userPassBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration["shaparak:UserName"]}:{configuration["shaparak:Password"]}"));

            requestLog.Token = userPassBase64;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userPassBase64);
            client.BaseAddress = new Uri("https://mms.shaparak.ir/merchant/");
            return client;
        }
    }
}
