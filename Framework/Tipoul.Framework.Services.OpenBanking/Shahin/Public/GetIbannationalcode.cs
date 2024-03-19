using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
using System.Text.Json;
using Tipoul.Framework.Services.OpenBanking.Shahin.Utilities;
using Tipoul.Framework.Services.OpenBanking.Shahin.Public.Models;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Public
{
    public class GetIbannationalcode
    {
       
        
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        public async Task<IbannationalcodeResult?> GetIbans(Ibannationalcode model, string ApiUrl, string UserName, string Password, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/inquiry/check-iban-nationalcode";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            CallApi _cai = new CallApi();
           
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await _cai.CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid, UserName, Password);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                return JsonSerializer.Deserialize<IbannationalcodeResult>(responseString);
           
        }
    }
}
