using System.Collections.Generic;

namespace Tipoul.Infrastructure.RequestLog.StorageModels
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
