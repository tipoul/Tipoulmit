using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.RequestLog.StorageModels.IranKishGateWay
{
    public class IranKishGateWayRequest
    {
        public IranKishGateWayRequest()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string URL { get; set; }

        public string Body { get; set; }

        public bool Success { get; set; }

        public string? Response { get; set; }

        public int? IranKishGateWayRequestExceptionId { get; set; }

        public string? Token { get; set; }

        public string? ExtraParameter { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreateDate { get; set; }

        public IranKishGateWayRequestException IranKishGateWayRequestException { get; set; }
    }
}
