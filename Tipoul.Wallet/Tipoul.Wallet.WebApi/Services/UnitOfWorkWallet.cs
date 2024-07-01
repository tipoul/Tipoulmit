using Tipoul.Wallet.WebApi.Data;
using Tipoul.Wallet.WebApi.Infrastructure;

namespace Tipoul.Wallet.WebApi.Services
{
    public class UnitOfWorkWallet : IUnitOfWorkWallet
    {
        private WalletWebApiContext _context;
        private IUsersRepo _usersRepo;
        private IBankAccountRepo _bankAccountRepo;
        

        public UnitOfWorkWallet(WalletWebApiContext context)
        {
            _context = context;
        }
        public IUsersRepo UsersRepo
        {
            get
            {
                return _usersRepo = _usersRepo ?? new UsersRepo(_context);
            }
        }
        public IBankAccountRepo BankAccountRepo
        {
            get
            {
                return _bankAccountRepo = _bankAccountRepo ?? new BankAccountRepo(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
