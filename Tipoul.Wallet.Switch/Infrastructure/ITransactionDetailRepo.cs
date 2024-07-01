using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Infrastructure
{
    public interface ITransactionDetailRepo
    {
        TransactionDetail GetById(long id);
    }
}
