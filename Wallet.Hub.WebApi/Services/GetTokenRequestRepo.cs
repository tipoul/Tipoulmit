using Microsoft.EntityFrameworkCore;
using Wallet.Hub.WebApi.Data;
using Wallet.Hub.WebApi.Entity;
using Wallet.Hub.WebApi.Infrastructure;

namespace Wallet.Hub.WebApi.Services
{
    public class GetTokenRequestRepo : IGetTokenRequestRepo
    {

        private HubWebApiContext _context;
        public GetTokenRequestRepo(HubWebApiContext context)
        {
            _context = context;
        }

        public OperationResult Insert(GetTokenRequest gettokenrequest)
        {
            var res = _context.GetTokenRequest.Add(gettokenrequest);

            if (res.State == EntityState.Added)
                return OperationResult.Success();

            else return OperationResult.Error();
        }
        public GetTokenResponse GetByToken(string token)
        {
            var entry = _context.GetTokenResponse.Where(x => x.HashedToken == token).FirstOrDefault();
            if (entry != null)
            {
                GetTokenResponse gtr = new GetTokenResponse();


                gtr.WTTN = entry.WTTN;
                gtr.WTTRN = entry.WTTRN;

                return gtr;
            }
            else
                return null;
        }
        public GetTokenRequest GetRequest(long id)
        {
            var entry = _context.GetTokenRequest.Where(x => x.Id == id).FirstOrDefault();
            if (entry != null)
               return entry;
            else
                return null;
        }
    }
}
