using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Infrastructure;

namespace Tipoul.Wallet.Switch.Services
{
    public class BalanceRepo: IBalanceRepo
    {
        private SwitchWalletContext _context;
        public BalanceRepo(SwitchWalletContext context)
        {
            _context = context;
        }
        public Balance GetById(long id)
        {
            var Balance = _context.Balance.Where(x => x.Id == id).FirstOrDefault();
            return Balance;
        }
        public Balance GetByBalance(long WalletId)
        {
            var Balance = _context.Balance.Where(x => x.WalletId== WalletId).FirstOrDefault();
            return Balance;
        }
    }
}
