using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Tipoul.Framework.Services.IranKishGateWay.Models;
using Tipoul.Framework.Services.RequestLog.DataAccessLayer;
using Tipoul.Framework.Services.RequestLog.StorageModels.IranKishGateWay;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.Framework.Services.IranKishGateWay
{
    public class IranKishGateWayService
    {
        private const string ApiUrl = "https://ikc.shaparak.ir/";

        private readonly IConfiguration configuration;

        private readonly RequestLogDbContext dbContext;

        private readonly RequestLogUtility<RequestLog.StorageModels.IranKishGateWay.IranKishGateWayRequest> requestLogUtility;

        public IranKishGateWayService(IConfiguration configuration, RequestLogDbContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            requestLogUtility = new RequestLogUtility<RequestLog.StorageModels.IranKishGateWay.IranKishGateWayRequest>()
                .Catch(CatchLogException)
                .Finally(async requestLog =>
                {
                    requestLog.Duration = DateTime.Now - requestLog.CreateDate;

                    dbContext.IranKishGateWayRequests.Add(requestLog);
                    await dbContext.SaveChangesAsync();
                });
        }

        private Task CatchLogException(IranKishGateWayRequest requestLog, Exception exception)
        {
            requestLog.Success = false;
            requestLog.IranKishGateWayRequestException = new IranKishGateWayRequestException
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace
            };

            return Task.CompletedTask;
        }

        public async Task<GetTokenResult?> GetToken(GetTokenModel model, string? extraParameterForlog)
        {
            var url = ApiUrl + "api/v3/tokenization/make";

            var requestLog = new IranKishGateWayRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    var postResult = await httpClient.PostCamelCaseStringContentAsync<GetTokenResult>(url, new RequestModel(model));
                    requestLog.Body = postResult.ModelString;
                    requestLog.Response = postResult.ResponseString;

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    return postResult.Result;
                }
            });
        }

        public async Task Redirect(ResponseUtilities responseUtilities, string tokenIdentity, string? extraParameteForLog)
        {
            var url = ApiUrl + "iuiv3/IPG/Index";

            var model = new { TokenIdentity = tokenIdentity };

            var requestLog = new IranKishGateWayRequest
            {
                Body = JsonSerializer.Serialize(model),
                URL = url,
                ExtraParameter = extraParameteForLog,
            };

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
            var url = ApiUrl + "api/v3/confirmation/purchase";

            var requestLog = new IranKishGateWayRequest
            {
                URL = url,
                ExtraParameter = extraParameteForLog,
            };

            return await requestLogUtility.Process(requestLog, async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    var postResult = await httpClient.PostCamelCaseStringContentAsync<ConfirmResult>(url, model);

                    if (postResult.Exception != null)
                        throw postResult.Exception;

                    requestLog.Success = true;

                    return postResult.Result;
                }
            });
        }
    }
}
