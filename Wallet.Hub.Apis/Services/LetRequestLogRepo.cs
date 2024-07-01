using Wallet.Hub.Apis.Data;
using Wallet.Hub.Apis.Entity;
using Wallet.Hub.Apis.Infrastructure;
using static Wallet.Hub.Apis.Services.GetTokenRequestRepo;

namespace Wallet.Hub.Apis.Services
{
    public class LetRequestLogRepo : ILetRequestLogRepo
    {

        private Context _context;
        public LetRequestLogRepo(Context context)
        {
            _context = context;
        }

        public void Insert(LetRequestLog letrequestlog)
        {
            _context.LetRequestLog.Add(letrequestlog);
        }

    }
}
