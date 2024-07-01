using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Infrastructure
{
    public interface ITransactionTypesRepo
    {
        TransactionTypes GetById(long id);
    }
}
