using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.Utilities;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Requests
{
    public class CallApi
    {
        public async Task<HttpResponseMessage> CallShahinApiAsync(string ApiUrl, string modelString, string access_token, long X_Obh_timestamp, string X_Obh_uuid, string UserName, string Password)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                string certFile = @"C:\Program Files\OpenSSL-Win64\bin\orgCertBundle.pfx";
                System.Net.ServicePointManager.Expect100Continue = false;
                httpClientHandler.ClientCertificates.Add(new X509Certificate2(certFile, "5024", X509KeyStorageFlags.MachineKeySet));
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (s, ce, ca, p) => true;
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.DefaultRequestHeaders.Add("X-Obh-timestamp", X_Obh_timestamp.ToString());
                    httpClient.DefaultRequestHeaders.Add("X-Obh-uuid", X_Obh_uuid);
                    string X_Obh_signature = ShahinUtility.CalcOBHSignature("POST", ApiUrl, httpClient.DefaultRequestHeaders, modelString, UserName, Password);
                    httpClient.DefaultRequestHeaders.Add("X-Obh-signature", X_Obh_signature);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                    var stringContent = new StringContent(modelString, null, "application/json");
                    
                    return await httpClient.PostAsync(ApiUrl, stringContent);
                   
                }
            }
            
        }
    }
}
