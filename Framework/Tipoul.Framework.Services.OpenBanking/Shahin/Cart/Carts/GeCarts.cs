using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models;
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
using Tipoul.Framework.Services.OpenBanking.Shahin.Utilities;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Cart.Carts
{
    public class GeCarts
    {
       
        private readonly RequestLogUtility<ShahinRequest> requestLogUtility;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        public async Task<CardInfoResult?> GetCardInfo(CardInfos model, string ApiUrl, string UserName, string Password, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/card/get-card-info";
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
                CardInfoResult resultModel = JsonSerializer.Deserialize<CardInfoResult>(responseString);
                
                return resultModel;
            
        }
    }
}
