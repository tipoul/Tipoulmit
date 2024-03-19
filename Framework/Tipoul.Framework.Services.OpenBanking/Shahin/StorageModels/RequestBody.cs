using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.StorageModels
{
    public class RequestBody
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public string Body { get; set; }

        public Request Request { get; set; }
    }
}
