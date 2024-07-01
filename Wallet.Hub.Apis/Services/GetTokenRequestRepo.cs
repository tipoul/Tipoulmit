using Microsoft.EntityFrameworkCore;
using Wallet.Hub.Apis.Data;
using Wallet.Hub.Apis.Entity;
using Wallet.Hub.Apis.Infrastructure;
using static Wallet.Hub.Apis.Services.GetTokenRequestRepo;

namespace Wallet.Hub.Apis.Services
{
    public class GetTokenRequestRepo : IGetTokenRequestRepo
    {

        private Context _context;
        public GetTokenRequestRepo(Context context)
        {
            _context = context;
        }

        public OperationResult Insert(GetTokenRequest gettokenrequest)
        {
            _context.GetTokenRequest.Add(gettokenrequest);

            var res = _context.GetTokenRequest.Add(gettokenrequest);

            if (res.State == EntityState.Added)
                return OperationResult.Success();

            else return OperationResult.Error();
        }

    }
}
