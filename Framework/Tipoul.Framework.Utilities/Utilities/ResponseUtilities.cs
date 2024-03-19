using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Utilities.Utilities
{
    public class ResponseUtilities
    {
        private readonly IHttpContextAccessor contextAccessor;

        public ResponseUtilities(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public async Task RedirectUsingPost<T>(string url, T model)
        {
            var responseBody =
                "<html>" +
                "   <body onload='document.forms[0].submit()'>" +
                $"       <form method='post' action='{url}'>" +
                $"          {string.Concat(GetInputs(model))}" +
                "        </form" +
                "   </body>" +
                "</html>";

            await contextAccessor.HttpContext.Response.WriteAsync(responseBody);

            static IEnumerable<string> GetInputs(T model)
            {
                foreach (var propertyInfo in typeof(T).GetProperties())
                    yield return $"<input type='hidden' name='{propertyInfo.Name}' value='{propertyInfo.GetValue(model)}' />";
            }
        }
    }
}
