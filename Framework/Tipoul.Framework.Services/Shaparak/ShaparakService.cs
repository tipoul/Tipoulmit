using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Tipoul.Framework.Services.RequestLog.DataAccessLayer;
using Tipoul.Framework.Services.RequestLog.StorageModels.Shaparak;
using Tipoul.Framework.Services.Shaparak.Models;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.Framework.Services.Shaparak
{
    public class ShaparakService
    {
        private readonly IConfiguration configuration;

        private readonly RequestLogDbContext dbContext;

        private readonly RequestLogUtility<RequestLog.StorageModels.Shaparak.ShaparakRequest> requestLogUtility;

        public ShaparakService(IConfiguration configuration, RequestLogDbContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            requestLogUtility = new RequestLogUtility<RequestLog.StorageModels.Shaparak.ShaparakRequest>()
                .Catch(CatchLogException)
                .Finally(async requestLog =>
                {
                    requestLog.Duration = DateTime.Now - requestLog.CreateDate;

                    await dbContext.SaveChangesAsync();
                });
        }

        private Task CatchLogException(ShaparakRequest requestLog, Exception exception)
        {
            requestLog.Success = false;
            requestLog.ShaparakRequestException = new ShaparakRequestException
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace
            };

            return Task.CompletedTask;
        }

        public async Task<ShaparakRequestResult?> CreateCustomerAndShopAsync(ShaparakRequestModel model, string? extraParameterForlog, int userId)
        {
            model.RequestType = Models.Enums.ShaparakRequestType.CreateCustomerAndShop;

            return await SendAsync(model, extraParameterForlog, userId);
        }

        public async Task<ShaparakRequestResult?> RequestNewGateWayAsync(ShaparakRequestModel model, string? extraParameterForlog, int userId)
        {
            model.RequestType = Models.Enums.ShaparakRequestType.RequestNewGateWay;

            return await SendAsync(model, extraParameterForlog, userId);
        }

        public async Task<ShaparakRequestResult?> UpdateAsync(ShaparakRequestModel model, string? extraParameterForlog, int userId)
        {
            model.RequestType = Models.Enums.ShaparakRequestType.Update;

            return await SendAsync(model, extraParameterForlog, userId);
        }

        public async Task<List<ShaparakStatusReportResult>?> GetStatusReportAsync(ShaparakStatusReportModel model, string? extraParameterForlog, int userId)
        {
            var url = "webService/readRequestCartableWithFilter/";

            var requestLog = new ShaparakRequest
            {
                ExtraParameter = extraParameterForlog,
                UserId = userId,
                Type = -1,
                URL = url,
                Body = JsonSerializer.Serialize(model)
            };

            dbContext.ShaparakRequests.Add(requestLog);

            await dbContext.SaveChangesAsync();

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var client = GetHttpClient(requestLog))
                {
                    var postResult = await client.PostCamelCaseStringContentAsync<List<ShaparakStatusReportResult>>(url, model);

                    requestLog.Body = postResult.ModelString;
                    requestLog.Response = postResult.ResponseString;

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    return postResult.Result;
                }
            });
        }

        private async Task<ShaparakRequestResult?> SendAsync(ShaparakRequestModel model, string? extraParameterForlog, int userId)
        {
            var url = "webService/writeExternalRequest/";

            var modelToSend = new[] { model };

            var requestLog = new ShaparakRequest
            {
                ExtraParameter = extraParameterForlog,
                UserId = userId,
                Type = (int)model.RequestType,
                URL = url,
                Body = JsonSerializer.Serialize(modelToSend)
            };

            dbContext.ShaparakRequests.Add(requestLog);

            await dbContext.SaveChangesAsync();

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var client = GetHttpClient(requestLog))
                {
                    var postResult = await client.PostCamelCaseStringContentAsync<List<ShaparakRequestResult>>(url, modelToSend);

                    requestLog.Body = postResult.ModelString;
                    requestLog.Response = postResult.ResponseString;

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    var finalResult = postResult.Result?.FirstOrDefault();

                    finalResult.RequestLogId = requestLog.Id;

                    return finalResult;
                }
            });
        }

        private HttpClient GetHttpClient(ShaparakRequest shaparakRequest)
        {
            var userPassBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration["shaparak:UserName"]}:{configuration["shaparak:Password"]}"));

            shaparakRequest.Token = userPassBase64;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userPassBase64);
            client.BaseAddress = new Uri("https://mms.shaparak.ir/merchant/");
            return client;
        }
    }
}
