using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Infrastructure;

namespace Tipoul.Wallet.Switch.Services
{
    public class WalletsRepo : IWalletsRepo
    {
        private SwitchWalletContext _context;
        public WalletsRepo(SwitchWalletContext context)
        {
            _context = context;
        }
        public Wallets GetById(long id)
        {
            var Wallets = _context.Wallets.Where(x => x.Id == id).FirstOrDefault();
            return Wallets;
        }
        public Wallets GetByWalletNo(int WalletNo)
        {
            var Wallets = _context.Wallets.Where(x => x.WalletNo == WalletNo).FirstOrDefault();
            return Wallets;
        }
        //public Wallets GetWalletDefault(long UserId)
        //{
        //    var Wallets = _context.Wallets.Where(x => x.UserId == UserId && x.FlagDefault==true).FirstOrDefault();
        //    return Wallets;
        //}
    }
}
