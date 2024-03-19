using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Infrastructure.RequestLog.StorageModels
{
    public class Request
    {
        public Request()
        {
            CreateDate = DateTime.Now;
            RequestCookies = new List<RequestCookie>();
            RequestForms = new List<RequestForm>();
            RequestHeaders = new List<RequestHeader>();
            RequestQueries = new List<RequestQuery>();
        }

        public int Id { get; set; }

        public string Path { get; set; }

        public string? Controller { get; set; }

        public string? Action { get; set; }

        public string Query { get; set; }

        public string Method { get; set; }

        public string ContentType { get; set; }

        public bool Success { get; set; }

        public string IpAddress { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreateDate { get; set; }

        public RequestBody RequestBody { get; set; }

        public RequestException RequestException { get; set; }

        public Response Response { get; set; }

        public List<RequestHeader> RequestHeaders { get; set; }

        public List<RequestQuery> RequestQueries { get; set; }

        public List<RequestCookie> RequestCookies { get; set; }

        public List<RequestForm> RequestForms { get; set; }
    }
}
