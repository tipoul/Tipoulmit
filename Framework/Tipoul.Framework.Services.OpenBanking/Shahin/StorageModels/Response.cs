using System.Collections.Generic;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.StorageModels
{
    public class Response
    {
        public Response()
        {
            ResponseHeaders = new List<ResponseHeader>();
        }

        public int Id { get; set; }

        public int RequestId { get; set; }

        public int StatusCode { get; set; }

        public string ContentType { get; set; }

        public string ResponseBody { get; set; }

        public Request Request { get; set; }

        public List<ResponseHeader> ResponseHeaders { get; set; }
    }
}
