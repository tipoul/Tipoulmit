using Wallet.Hub.Apis.Data;
using Wallet.Hub.Apis.Entity;
using Wallet.Hub.Apis.Infrastructure;
using static Wallet.Hub.Apis.Services.GetTokenRequestRepo;

namespace Wallet.Hub.Apis.Services
{
    public class VerifyRequestLogRepo : IVerifyRequestLogRepo
    {

        private Context _context;
        public VerifyRequestLogRepo(Context context)
        {
            _context = context;
        }

        public void Insert(VerifyRequestLog verifyrequestlog)
        {
            _context.VerifyRequestLog.Add(verifyrequestlog);
        }

    }
}
