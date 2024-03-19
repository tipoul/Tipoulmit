using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Tipoul.Framework.Services.RequestLog.DataAccessLayer;
using Tipoul.Framework.Services.SepehrGateWay.Models;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.Framework.Services.SepehrGateWay
{
    public class SepehrGateWayService
    {
        private const string ApiKey = "https://mabna.shaparak.ir:8081/V1/PeymentApi/";

        private readonly RequestLogDbContext dbContext;

        private readonly RequestLogUtility<RequestLog.StorageModels.SepehrGateWay.SepehrGateWayRequest> requestLogUtility;

        public SepehrGateWayService(RequestLogDbContext dbContext)
        {
            this.dbContext = dbContext;
            requestLogUtility = new RequestLogUtility<RequestLog.StorageModels.SepehrGateWay.SepehrGateWayRequest>()
                .Catch(CatchException)
                .Finally(async sepehrGateWayRequest =>
                {
                    sepehrGateWayRequest.Duration = DateTime.Now - sepehrGateWayRequest.CreateDate;

                    await dbContext.SaveChangesAsync();
                });
        }

        private Task CatchException(RequestLog.StorageModels.SepehrGateWay.SepehrGateWayRequest sepehrGateWayRequest, Exception exception)
        {
            sepehrGateWayRequest.Success = false;
            sepehrGateWayRequest.SepehrgateWayRequestException = new RequestLog.StorageModels.SepehrGateWay.SepehrGateWayRequestException
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace
            };

            return Task.CompletedTask;
        }

        public async Task<GetTokenResult?> GetToken(GetTokenModel model, string? extraParameteForLog)
        {
            var url = ApiKey + "GetToken";

            var requestLog = new RequestLog.StorageModels.SepehrGateWay.SepehrGateWayRequest
            {
                URL = url,
                ExtraParameter = extraParameteForLog
            };

            dbContext.SepehrGateWayRequests.Add(requestLog);
            await dbContext.SaveChangesAsync();

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var webClient = new HttpClient())
                {
                    var postResult = await webClient.PostCamelCaseStringContentAsync<GetTokenResult>(url, model);

                    requestLog.Body = postResult.ModelString;
                    requestLog.Response = postResult.ResponseString;

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    return postResult.Result;
                }
            });
        }

        public async Task Redirect(ResponseUtilities responseUtilities, RedirectModel model, string? extraParameteForLog)
        {
            var url = "https://mabna.shaparak.ir:8080/Pay";

            var requestLog = new RequestLog.StorageModels.SepehrGateWay.SepehrGateWayRequest
            {
                Body = JsonSerializer.Serialize(model),
                URL = url,
                ExtraParameter = extraParameteForLog,
            };

            dbContext.SepehrGateWayRequests.Add(requestLog);
            await dbContext.SaveChangesAsync();

            await requestLogUtility.Process(requestLog, async () =>
            {
                await responseUtilities.RedirectUsingPost(url, model);

                requestLog.Response = "Redirect";
                requestLog.Success = true;

                return 0;
            });
        }

        public async Task<ConfirmResult?> Confirm(ConfirmModel model, string? extraParameteForLog)
        {
            var url = ApiKey + "Advice";

            var requestLog = new RequestLog.StorageModels.SepehrGateWay.SepehrGateWayRequest
            {
                URL = url,
                ExtraParameter = extraParameteForLog
            };

            dbContext.SepehrGateWayRequests.Add(requestLog);
            await dbContext.SaveChangesAsync();

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var webClient = new HttpClient())
                {
                    var postResult = await webClient.PostCamelCaseStringContentAsync<ConfirmResult>(url, model);

                    requestLog.Body = postResult.ModelString;
                    requestLog.Response = postResult.ResponseString;

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    return postResult.Result;
                }
            });
        }
    }
}
