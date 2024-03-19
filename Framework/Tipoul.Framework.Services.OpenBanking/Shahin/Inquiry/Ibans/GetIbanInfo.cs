using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
using Tipoul.Framework.Services.OpenBanking.Shahin.Utilities;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans
{
    public class GetIbanInfo
    {

        private readonly RequestLogUtility<ShahinRequest> requestLogUtility;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        public async Task<IbanInfoResult?> GetIbanInfos(IbanInfo model, string Address, string Username, string Password, string access_token, string? extraParameterForlog)
        {
            var url = Address + "/api/aisp/get-iban-info";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };

            CallApi _cai = new CallApi();

            var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
            long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
            string X_Obh_uuid = Guid.NewGuid().ToString();
            var response = await _cai.CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid, Username, Password);
            var responseString = await response.Content.ReadAsStringAsync();
            requestLog.Body = modelString;
            requestLog.Response = responseString;
            requestLog.Success = response.IsSuccessStatusCode;
            IbanInfoResult resultModel = JsonSerializer.Deserialize<IbanInfoResult>(responseString);
            return resultModel;

        }
    }
}
