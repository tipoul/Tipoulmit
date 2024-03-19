using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
using Tipoul.Framework.Services.OpenBanking.Shahin.Utilities;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Financial
{
    public class TransactionInquiry
    {
        string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        string UserName = ConfigurationManager.AppSettings["UserName"];
        string Password = ConfigurationManager.AppSettings["Password"];
        private readonly RequestLogUtility<ShahinRequest> requestLogUtility;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        public async Task<TransactionInquiryResult?> TransactionInquirys(TransactionInquiries model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/pisp/transaction-inquiry";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            CallApi _cai = new CallApi();
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await _cai.CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid, UserName, Password);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = true;
                return JsonSerializer.Deserialize<TransactionInquiryResult>(responseString);
            });
        }
    }
}
