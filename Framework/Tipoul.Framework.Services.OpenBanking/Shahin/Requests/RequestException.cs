using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.Services.OpenBanking.Shahin.StorageModels;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Requests
{
    public class RequestException
    {
        public RequestException()
        {
            RequestInnerExceptions = new List<RequestInnerException>();
        }

        public int Id { get; set; }

        public int RequestId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public Request Request { get; set; }

        public List<RequestInnerException> RequestInnerExceptions { get; set; }
    }
}
