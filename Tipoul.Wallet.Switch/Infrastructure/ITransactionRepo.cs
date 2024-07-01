using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Infrastructure
{
    public interface ITransactionRepo
    {
        Transactions GetById(long id);
        Transactions GetByWTTN(string WTTN);
        OperationResult Insert(Transactions transaction);
    }
}
