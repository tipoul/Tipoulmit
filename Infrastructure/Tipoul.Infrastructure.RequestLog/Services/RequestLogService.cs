using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Infrastructure.RequestLog.Services
{
    public class RequestLogService
    {
        private StorageModels.Request request;

        internal StorageModels.Request SetRequest(StorageModels.Request request)
        {
            return this.request = request;
        }

        public int RequestId => request.Id;
    }
}
