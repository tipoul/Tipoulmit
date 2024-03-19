using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.StorageModels
{
    public class RequestCookie
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public Request Request { get; set; }
    }
}
