namespace Tipoul.Wallet.WebApi.Infrastructure
{
    public interface IUnitOfWorkWallet
    {
        IUsersRepo UsersRepo { get; }
        IBankAccountRepo BankAccountRepo { get; }

        void Save();
    }
}
