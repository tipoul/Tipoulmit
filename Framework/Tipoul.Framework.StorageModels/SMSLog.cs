using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class SMSLog
    {
        public SMSLog()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string? Token { get; set; }

        public string PhoneNumber { get; set; }

        public string VerificationCode { get; set; }

        public bool IsSuccess { get; set; }

        public long MessageId { get; set; }

        public string? Message { get; set; }

        public string? ExceptionMessage { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
