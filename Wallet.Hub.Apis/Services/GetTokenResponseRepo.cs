using Wallet.Hub.Apis.Data;
using Wallet.Hub.Apis.Entity;
using Wallet.Hub.Apis.Infrastructure;
using static Wallet.Hub.Apis.Services.GetTokenRequestRepo;

namespace Wallet.Hub.Apis.Services
{
    public class GetTokenResponseRepo : IGetTokenResponseRepo
    {

        private Context _context;
        public GetTokenResponseRepo(Context context)
        {
            _context = context;
        }

        public void Insert(GetTokenResponse gettokenresponse)
        {
            _context.GetTokenResponse.Add(gettokenresponse);
        }

    }
}
