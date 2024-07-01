using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Infrastructure
{
    public interface IWalletsRepo
    {
        Wallets GetById(long id);
        //Wallets GetByWalletNo(int WallertNo);
        //Wallets GetWalletDefault(long UserId);
    }
}
