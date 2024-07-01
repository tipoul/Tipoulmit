using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Tipoul.Console.WebApi;
using Tipoul.Shaparak.Switch.Model.GetToken;
using Tipoul.Wallet.Models;
using static System.Net.WebRequestMethods;


namespace Tipoul.Wallet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        private readonly string TokenUrl;
        private readonly string ApiUrl;
        private readonly string UserName;
        private readonly string Password;
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };


        public HomeController(IConfiguration iConfig, IHttpContextAccessor contextAccessor)
        {
            // _logger = logger;
            configuration = iConfig;
            TokenUrl = configuration.GetSection("shahin").GetSection("TokenUrl").Value;
            ApiUrl = configuration.GetSection("shahin").GetSection("ApiUrl").Value;
            UserName = configuration.GetSection("shahin").GetSection("UserName").Value;
            Password = configuration.GetSection("shahin").GetSection("Password").Value;
            _contextAccessor = contextAccessor;
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> console([FromBody] Data data)
        {
            string accessToken = "";

            GetTokenModel model = new GetTokenModel();
            model.Amount = data.amount;
            model.FactorNumber = "";
            model.IPG = "BPT";
            //model.ValidCardNum = null;
            model.PayerName = "";
            model.PayerUserId = null;
            model.BlankForPayer = data.nationalcode;
            model.BlankForTransaction = "";
            model.CallBackUrl = "https://localhost:7260/Result";
            model.PayerMobile = data.mobile;
            model.Description = "";
            model.GateToken = "66b3cebc-b125-4c73-90d3-d9ace2a68b44";

            var ApiUrl = "https://localhost:7260/Pay/v1/getToken";

            var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
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
    public class Data
    {

        public long amount { get; set; }
        public string mobile { get; set; }
        public string nationalcode { get; set; }
    }
}
