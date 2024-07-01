namespace Tipoul.Wallet.Switch.Infrastructure
{
    public interface IUnitOfWork
    {
       
        IBalanceRepo BalanceRepo { get; }
       
        ITransactionDetailRepo TransactionDetailRepo { get; }
        ITransactionRepo TransactionRepo { get; }
        ITransactionTypesRepo TransactionTypesRepo { get; }
        ITransactionTypeUserRepo TransactionTypeUserRepo { get; }
        IUsersRepo UsersRepo { get; }
        IWalletsRepo WalletsRepo { get; }
        

        void Save();
    }
}
