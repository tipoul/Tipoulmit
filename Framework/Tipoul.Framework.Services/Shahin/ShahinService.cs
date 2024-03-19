using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tipoul.Framework.Services.RequestLog.DataAccessLayer;
using Tipoul.Framework.Services.RequestLog.StorageModels.Shahin;
using Tipoul.Framework.Services.Shahin.Models;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tipoul.Framework.Services.Shahin
{
    public class ShahinService
    {
        private const string TokenUrl = "https://94.184.140.112:443/v0.3/obh/oauth/token";
        private const string ApiUrl = "https://94.184.140.112:5443/v0.3/obh";
        private readonly IConfiguration configuration;
        private readonly RequestLogDbContext dbContext;
        private readonly RequestLogUtility<RequestLog.StorageModels.Shahin.ShahinRequest> requestLogUtility;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        private string Shahin_UserName = "JdYabK3WTT";
        private string Shahin_Password = "oeT3YCgL10";
        public ShahinService(IConfiguration configuration, RequestLogDbContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;

            requestLogUtility = new RequestLogUtility<RequestLog.StorageModels.Shahin.ShahinRequest>()
                .Catch(CatchLogException)
                .Finally(async requestLog =>
                {
                    requestLog.Duration = DateTime.Now - requestLog.CreateDate;
                    //dbContext.ShahinRequests.Add(requestLog);
                    await dbContext.SaveChangesAsync();
                });
        }
        private Task CatchLogException(RequestLog.StorageModels.Shahin.ShahinRequest requestLog, Exception exception)
        {
            requestLog.Success = false;
            requestLog.ShahinRequestException = new RequestLog.StorageModels.Shahin.ShahinRequestException
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace
            };

            return Task.CompletedTask;
        }

        private static GetTokenResult? tokenResult = null;
        public async Task<GetTokenResult?> GetToken()
        {
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
                    URL = TokenUrl
                };
                await requestLogUtility.Process(requestLog, () =>
                {
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
                            requestLog.Body = valuesString;
                            requestLog.Response = responseBody;
                            requestLog.Success = true;

                            tokenResult = JsonSerializer.Deserialize<GetTokenResult>(responseBody);
                            return Task.FromResult(tokenResult);
                        }
                    }
                });
                return tokenResult;
            }
            else
            {
                return tokenResult;
            }
        }
        public async Task<TransferResultModel?> Transfer(TranferModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/pisp/transfer";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = true;
                return JsonSerializer.Deserialize<TransferResultModel>(responseString);
            });
        }
        public async Task<TransactionInquiryResultModel?> TransactionInquiry(TransactionInquiryModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/pisp/transaction-inquiry";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = true;
                return JsonSerializer.Deserialize<TransactionInquiryResultModel>(responseString);
            });
        }
        public async Task<AccountBalanceResultModel?> GetAccountBalance(AccountBalanceModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/aisp/get-account-balance";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                //response.IsSuccessStatusCode;
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = true;
                return JsonSerializer.Deserialize<AccountBalanceResultModel>(responseString);
            });
        }
        public async Task<AccountStatementResultModel?> GetAccountStatement(AccountStatementModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/aisp/get-account-statement";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                return JsonSerializer.Deserialize<AccountStatementResultModel>(responseString);
            });
        }
        public async Task<IbanResultModel?> GetIban(IbanModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/aisp/get-iban";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                return JsonSerializer.Deserialize<IbanResultModel>(responseString);
            });
        }
        public async Task<IbanInfoResultModel?> GetIbanInfo(IbanInfoModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/aisp/get-iban-info";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                return JsonSerializer.Deserialize<IbanInfoResultModel>(responseString);
            });
        }
        public async Task<CardInfoResultModel?> GetCardInfo(CardInfoModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/card/get-card-info";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                return JsonSerializer.Deserialize<CardInfoResultModel>(responseString);
            });
        }



        private async Task<HttpResponseMessage> CallShahinApiAsync(string ApiUrl, string modelString, string access_token, long X_Obh_timestamp, string X_Obh_uuid)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                string certFile = @"C:\Program Files\OpenSSL-Win64\bin\orgCertBundle.pfx";
                httpClientHandler.ClientCertificates.Add(new X509Certificate2(certFile, "5024", X509KeyStorageFlags.MachineKeySet));
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (s, ce, ca, p) => true;
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.DefaultRequestHeaders.Add("X-Obh-timestamp", X_Obh_timestamp.ToString());
                    httpClient.DefaultRequestHeaders.Add("X-Obh-uuid", X_Obh_uuid);
                    string X_Obh_signature = ShahinUtility.CalcOBHSignature("POST", ApiUrl, httpClient.DefaultRequestHeaders, modelString, Shahin_UserName, Shahin_Password);
                    httpClient.DefaultRequestHeaders.Add("X-Obh-signature", X_Obh_signature);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                    var stringContent = new StringContent(modelString, null, "application/json");
                    return await httpClient.PostAsync(ApiUrl, stringContent);
                }
            }
        }
    }
}
