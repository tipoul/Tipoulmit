using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Tipoul.Framework.Services.RequestLog.DataAccessLayer;
using Tipoul.Framework.Services.RequestLog.StorageModels.Sepehr;
using Tipoul.Framework.Services.Sepehr.Models;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.Framework.Services.Sepehr
{
    public class SepehrService
    {
        private const string BaseUrl = "https://sepehrhub.sepehrpay.com:8095";

        private readonly IConfiguration configuration;

        private readonly RequestLogDbContext dbContext;

        private readonly RequestLogUtility<SepehrRequest> requestLogUtility;

        public SepehrService(IConfiguration configuration, RequestLogDbContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            requestLogUtility = new RequestLogUtility<SepehrRequest>()
                .Catch(CatchException)
                .Finally(async sepehrRequest =>
                {
                    sepehrRequest.Duration = DateTime.Now - sepehrRequest.CreateDate;

                    await dbContext.SaveChangesAsync();
                });
        }

        private Task CatchException(SepehrRequest sepehrRequest, Exception exception)
        {
            sepehrRequest.Success = false;
            sepehrRequest.SepehrRequestException = new SepehrRequestException
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace
            };

            return Task.CompletedTask;
        }

        public async Task<LoginResult?> LoginAsync(string? extraParameterForLog)
        {
            var loginModel = new
            {
                UserName = configuration["sepehr:UserName"],
                Password = configuration["sepehr:Password"]
            };

            return await PostAsync<LoginResult>("api/Security/Login", loginModel, extraParameterForLog);
        }

        public async Task<RequestResult?> RegisterAsync(RequestModel model, string? extraParameterForLog, string token)
        {
            return await PostAsync<RequestResult>("api/Pardakhtyar/Register", model, extraParameterForLog, token);
        }

        public async Task<RequestResult?> UpdateTerminal(RequestModel model, string? extraParameterForLog, string token)
        {
            return await PostAsync<RequestResult>("api/Pardakhtyar/UpdateTerminal", model, extraParameterForLog, token);
        }

        private async Task<T?> PostAsync<T>(string url, object model, string? extraParameterForLog, string token = null)
        {
            var requestLog = new SepehrRequest
            {
                ExtraParameter = extraParameterForLog,
                Token = token,
                URL = url
            };

            dbContext.SepehrRequests.Add(requestLog);

            await dbContext.SaveChangesAsync();

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var client = GetHttpClient(token))
                {
                    var postResult = await client.PostCamelCaseStringContentAsync<T>(url, model);

                    requestLog.Body = postResult.ModelString;
                    requestLog.Response = postResult.ResponseString;

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    requestLog.SepehrRequestLogId = requestLog.Id;

                    return postResult.Result;
                }
            });
        }

        private HttpClient GetHttpClient(string token = null)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            if (!string.IsNullOrWhiteSpace(token))
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("jwtToken", token);

            return client;
        }
    }
}
