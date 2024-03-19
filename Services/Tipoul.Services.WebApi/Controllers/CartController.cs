
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Tipoul.Services.Shared.Models.Common;
using System.Web.Http;
using Tipoul.Services.Shared.Models.Banking;
using Tipoul.Framework.Services.Shahin;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace Tipoul.Services.WebApi.Controllers
{
    public class CartController : ApiController
    {
        private readonly ShahinService shahinService;

        public CartController()
        {
            
        }
        
        [System.Web.Http.AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpGet("{Id}")]
        public async Task<ApiResult<string>> GetById(long Id)
        {
            string TokenUrl = "https://94.184.140.112:443/v0.3/obh/oauth/token";
              string Shahin_UserName = "JdYabK3WTT";
         string Shahin_Password = "oeT3YCgL10";
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    Uri baseUri = new Uri(TokenUrl);
                    httpClient.BaseAddress = baseUri;
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.ConnectionClose = true;
                    //Post body content
                    var values = new List<KeyValuePair<string, string>>();
                    values.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                    values.Add(new KeyValuePair<string, string>("bank", "BSI"));
                    var content = new FormUrlEncodedContent(values);
                    var authenticationString = Shahin_UserName + ":" + Shahin_Password;
                    var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, TokenUrl);
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
                    requestMessage.Content = content;

                    var task = httpClient.SendAsync(requestMessage);
                    var response = task.Result;
                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
                    var valuesString = JsonSerializer.Serialize(values, camelCaseSettings);
                    //requestLog.Body = valuesString;
                    //requestLog.Response = responseBody;
                    //requestLog.Success = true;

                    //tokenResult = JsonSerializer.Deserialize<GetTokenResult>(responseBody);
                    //return Task.FromResult(tokenResult);
                }
            }



            //ShahinService shahinService = new ShahinService();
            //Framework.ShahinService.ShahinOperation.Models.GetTokenResult token = await shahinService.GetToken();
            return null;
            //return "minajjjjjjjjjjjjjjjj";
        }
        [System.Web.Http.HttpPost]
        public async Task<string> Create([System.Web.Http.FromBody] string project)
        {
            return "aaaa";

        }


    }
}
