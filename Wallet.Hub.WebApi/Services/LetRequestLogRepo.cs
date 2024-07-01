using Microsoft.EntityFrameworkCore;
using Wallet.Hub.WebApi.Data;
using Wallet.Hub.WebApi.Entity;
using Wallet.Hub.WebApi.Infrastructure;

namespace Wallet.Hub.WebApi.Services
{
    public class LetRequestLogRepo : ILetRequestLogRepo
    {

        private HubWebApiContext _context;
        public LetRequestLogRepo(HubWebApiContext context)
        {
            _context = context;
        }

        public OperationResult Insert(LetRequestLog letrequestlog)
        {
          


            var res = _context.LetRequestLog.Add(letrequestlog);

            if (res.State == EntityState.Added)
                return OperationResult.Success();

            else return OperationResult.Error();
        }

    }
}
