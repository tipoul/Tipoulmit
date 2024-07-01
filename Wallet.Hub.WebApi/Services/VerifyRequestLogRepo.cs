using Microsoft.EntityFrameworkCore;
using Wallet.Hub.WebApi.Data;
using Wallet.Hub.WebApi.Entity;
using Wallet.Hub.WebApi.Infrastructure;

namespace Wallet.Hub.WebApi.Services
{
    public class VerifyRequestLogRepo : IVerifyRequestLogRepo
    {

        private HubWebApiContext _context;
        public VerifyRequestLogRepo(HubWebApiContext context)
        {
            _context = context;
        }

        public void Insert(VerifyRequestLog verifyrequestlog)
        {
            _context.VerifyRequestLog.Add(verifyrequestlog);
        }

    }
}
