using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Requests
{
    public class ShahinException
    {
        public int Id { get; set; }

        public int ShahinRequestId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string? InnerMessage { get; set; }

        public string? InnerStackTrace { get; set; }

        public ShahinRequest ShahinRequest { get; set; }
    }
}
