using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Services.Shared.Models.Common;
using Tipoul.Services.Shared.Models.Pay;

namespace Tipoul.Services.Agent
{
    public class GateWayService
    {
        private const string GATEWAY_SERVICE_URI = "https://api.tipoul.com";

        private readonly ResponseUtilities responseUtilities;

        private readonly IHttpContextAccessor httpContextAccessor;

        public GateWayService(ResponseUtilities responseUtilities, IHttpContextAccessor httpContextAccessor)
        {
            this.responseUtilities = responseUtilities;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetTokenResult> GetToken(GetTokenModel model)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostCamelCaseStringContentAsync<ApiResult<GetTokenResult>>(GATEWAY_SERVICE_URI + "/pay/v1/getToken", model);

                if (response.Exception != null)
                    throw response.Exception;

                if (!response.Result.Success)
                    throw new Exception(response.Result + ": " + response.Result.Message);

                return response.Result.Result;
            }
        }

        public async Task StartAsync(StartModel model)
        {
            await responseUtilities.RedirectUsingPost(GATEWAY_SERVICE_URI + "/pay/v1/start", model);
        }

        public async Task<ConfirmResult?> ConfirmAsync(ConfirmModel model)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostCamelCaseStringContentAsync<ApiResult<ConfirmResult>>(GATEWAY_SERVICE_URI + "/pay/v1/confirm", model);

                if (response.Exception != null)
                    throw response.Exception;

                if (!response.Result.Success)
                    throw new Exception(response.Result + ": " + response.Result.Message);

                return response.Result.Result;
            }
        }
    }
}
