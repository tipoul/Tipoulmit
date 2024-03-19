using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.RequestLog.StorageModels.ShaparakTax
{
    public class ShaparakTaxRequest
    {
        public ShaparakTaxRequest()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string TrackingCode { get; set; }

        public int UserId { get; set; }

        public string URL { get; set; }

        public string? Body { get; set; }

        public bool Success { get; set; }

        public string? Response { get; set; }

        public int? ShaparakTaxRequestExceptionId { get; set; }

        public string? Token { get; set; }

        public string? ExtraParameter { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreateDate { get; set; }

        public ShaparakTaxRequestException ShaparakTaxRequestException { get; set; }
    }
}
