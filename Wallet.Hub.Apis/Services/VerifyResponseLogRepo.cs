using Wallet.Hub.Apis.Data;
using Wallet.Hub.Apis.Entity;
using Wallet.Hub.Apis.Infrastructure;
using static Wallet.Hub.Apis.Services.GetTokenRequestRepo;

namespace Wallet.Hub.Apis.Services
{
    public class VerifyResponseLogRepo : IVerifyResponseLogRepo
    {

        private Context _context;
        public VerifyResponseLogRepo(Context context)
        {
            _context = context;
        }

        public void Insert(VerifyResponseLog verifyresponselog)
        {
            _context.VerifyResponseLog.Add(verifyresponselog);
        }

    }
}
