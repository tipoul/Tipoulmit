using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Infrastructure
{
    public interface ITransactionTypeUserRepo
    {
        TransactionTypeUser GetById(long id);
        TransactionTypeUser GetByTypeUser(long TransactionTypeId, long UserId);
    }
}
