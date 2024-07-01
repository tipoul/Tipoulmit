using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Wallet.Hub.WebApi.Data;
using Wallet.Hub.WebApi.Entity;
using Wallet.Hub.WebApi.Infrastructure;

namespace Wallet.Hub.WebApi.Services
{
    public class GetTokenResponseRepo : IGetTokenResponseRepo
    {

        private HubWebApiContext _context;
        public GetTokenResponseRepo(HubWebApiContext context)
        {
            _context = context;
        }

        public OperationResult Insert(GetTokenResponse gettokenresponse)
        {
           

            var res = _context.GetTokenResponse.Add(gettokenresponse);

            if (res.State == EntityState.Added)
                return OperationResult.Success();

            else return OperationResult.Error();



            
        }
        public GetTokenResponse GetByToken(string token)
        {
            var entry = _context.GetTokenResponse.Where(x => x.HashedToken == token).FirstOrDefault();
            if (entry != null)
                return entry;           
            else
                return null;
        }
       
    }
}
