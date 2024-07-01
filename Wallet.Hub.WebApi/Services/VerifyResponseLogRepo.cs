using Microsoft.EntityFrameworkCore;
using Wallet.Hub.WebApi.Data;
using Wallet.Hub.WebApi.Entity;
using Wallet.Hub.WebApi.Infrastructure;

namespace Wallet.Hub.WebApi.Services
{
    public class VerifyResponseLogRepo : IVerifyResponseLogRepo
    {

        private HubWebApiContext _context;
        public VerifyResponseLogRepo(HubWebApiContext context)
        {
            _context = context;
        }

        public void Insert(VerifyResponseLog verifyresponselog)
        {
            _context.VerifyResponseLog.Add(verifyresponselog);
        }

    }
}
