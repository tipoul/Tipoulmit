using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
using Tipoul.Framework.Services.OpenBanking.Shahin.Token.Models;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Token
{
    public class GetToken
    {
       
      
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        private static GetTokenResult? tokenResult = null;

        
        public async Task<GetTokenResult?> GetTokens(string Address,string Username,string Password)
        {
            var url = Address + "/oauth/token";
            if (tokenResult != null)
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(tokenResult.nbf).ToLocalTime();
                if (DateTime.Now > dt.AddSeconds(tokenResult.expires_in))
                    tokenResult = null;
            }
            if (tokenResult == null)
            {
                var requestLog = new ShahinRequest
                {
                    ExtraParameter = "",
                    URL = url
                };
                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        Uri baseUri = new Uri(url);
                        httpClient.BaseAddress = baseUri;
                        httpClient.DefaultRequestHeaders.Clear();
                        httpClient.DefaultRequestHeaders.ConnectionClose = true;
                        //Post body content
                        var values = new List<KeyValuePair<string, string>>();
                        values.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                        values.Add(new KeyValuePair<string, string>("bank", "BSI"));
                        var content = new FormUrlEncodedContent(values);
                        var authenticationString = Username + ":" + Password;
                        var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
                        var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
                        requestMessage.Content = content;

                        var task = httpClient.SendAsync(requestMessage);
                        var response = task.Result;
                        response.EnsureSuccessStatusCode();
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        var camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
                        var valuesString = JsonSerializer.Serialize(values, camelCaseSettings);
                        requestLog.Body = valuesString;
                        requestLog.Response = responseBody;
                        requestLog.Success = true;

                        tokenResult = JsonSerializer.Deserialize<GetTokenResult>(responseBody);
                        
                    }
                }
                
               
                return tokenResult;
            }
            else
            {
                return tokenResult;
            }
        }
    }
}
