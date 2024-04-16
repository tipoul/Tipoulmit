using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Shaparak.Services.BehPardakhtGateWay;
using Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest;
using Tipoul.Shaparak.Services.Data;
using Tipoul.Shaparak.Switch.Model.GetToken;

namespace Wallet3.Controllers
{
    public class ResultController : Controller
    {
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        public async Task<IActionResult> Index()
        {
            string accessToken = "";       

            var ApiUrl = "https://localhost:7260/Pay/v1/Callback";

            var modelString = JsonSerializer.Serialize("", camelCaseSettings);
            var stringContent = new StringContent(modelString, null, "application/json");

            using (var httpClient = new HttpClient())
            {
                var a = await httpClient.PostAsync(ApiUrl, stringContent);
                string resultContent = await a.Content.ReadAsStringAsync();
                var resultModel = JsonSerializer.Deserialize<Tokenresult>(resultContent);
                accessToken = resultModel.accessToken;
            }
            return Json(new { success = true, responseText = accessToken });
        }
    }
}
