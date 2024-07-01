using Microsoft.EntityFrameworkCore;
using Wallet.Hub.WebApi.Data;
using Wallet.Hub.WebApi.Entity;
using Wallet.Hub.WebApi.Infrastructure;

namespace Wallet.Hub.WebApi.Services
{
    public class LetResponseLogRepo : ILetResponseLogRepo
    {

        private HubWebApiContext _context;
        public LetResponseLogRepo(HubWebApiContext context)
        {
            _context = context;
        }

        public void Insert(LetResponseLog letresponselog)
        {
            _context.LetResponseLog.Add(letresponselog);
        }

    }
}
