using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Infrastructure
{
    public interface IBalanceRepo
    {
        Balance GetById(long id);
        Balance GetByBalance( long WalletId);
    }
}
