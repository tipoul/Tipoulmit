using Wallet.Hub.Apis.Data;
using Wallet.Hub.Apis.Entity;
using Wallet.Hub.Apis.Infrastructure;
using static Wallet.Hub.Apis.Services.GetTokenRequestRepo;

namespace Wallet.Hub.Apis.Services
{
    public class LetResponseLogRepo : ILetResponseLogRepo
    {

        private Context _context;
        public LetResponseLogRepo(Context context)
        {
            _context = context;
        }

        public void Insert(LetResponseLog letresponselog)
        {
            _context.LetResponseLog.Add(letresponselog);
        }

    }
}
