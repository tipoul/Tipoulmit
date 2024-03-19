using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tipoul.Framework.Utilities.Extentions
{
    public static class HttpClientExtentionMethods
    {
        public static async Task<HttpClientpostCamelCaseStringContentResult<TResult>> PostCamelCaseStringContentAsync<TResult>(this HttpClient httpClient, string url, object model)
        {
            var camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

            var modelString = JsonSerializer.Serialize(model, camelCaseSettings);

            var stringContent = new StringContent(modelString, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, stringContent);

            if (!response.IsSuccessStatusCode)
                return new HttpClientpostCamelCaseStringContentResult<TResult>(modelString, new Exception(await response.Content.ReadAsStringAsync()));

            var responseString = await response.Content.ReadAsStringAsync();

            return new HttpClientpostCamelCaseStringContentResult<TResult>(modelString, responseString, JsonSerializer.Deserialize<TResult>(responseString, camelCaseSettings));
        }

        public class HttpClientpostCamelCaseStringContentResult<TResult>
        {
            public HttpClientpostCamelCaseStringContentResult(string modelString, string responseString, TResult? result)
            {
                ModelString = modelString;
                ResponseString = responseString;
                Result = result;
            }

            public HttpClientpostCamelCaseStringContentResult(string modelString, Exception exception)
            {
                ModelString = modelString;
                Exception = exception;
            }

            public string ModelString { get; set; }

            public string? ResponseString { get; set; }

            public TResult? Result { get; set; }

            public Exception? Exception { get; set; }
        }
    }
}
