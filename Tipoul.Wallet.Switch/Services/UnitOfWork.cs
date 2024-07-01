using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Infrastructure;

namespace Tipoul.Wallet.Switch.Services
{
    public class UnitOfWork
    {
        private SwitchWalletContext _context;
        private IBalanceRepo _balanceRepo;
       
        private ITransactionRepo _transactionRepo;
        private ITransactionDetailRepo _transactionDetailRepo;
        private ITransactionTypesRepo _transactionTypesRepo;
        private ITransactionTypeUserRepo _transactionTypeUserRepo;
        private IUsersRepo _usersRepo;
        private IWalletsRepo _walletsRepo;
       
        public UnitOfWork(SwitchWalletContext context)
        {
            _context = context;
        }
        public IBalanceRepo BalanceRepo
        {
            get
            {
                return _balanceRepo = _balanceRepo ?? new BalanceRepo(_context);
            }
        }
       
        public ITransactionRepo TransactionRepo
        {
            get
            {
                return _transactionRepo = _transactionRepo ?? new TransactionRepo(_context);
            }
        }
        public ITransactionDetailRepo TransactionDetailRepo
        {
            get
            {
                return _transactionDetailRepo = _transactionDetailRepo ?? new TransactionDetailRepo(_context);
            }
        }
        public ITransactionTypesRepo TransactionTypesRepo
        {
            get
            {
                return _transactionTypesRepo = _transactionTypesRepo ?? new TransactionTypesRepo(_context);
            }
        }
        public ITransactionTypeUserRepo TransactionTypeUserRepo
        {
            get
            {
                return _transactionTypeUserRepo = _transactionTypeUserRepo ?? new TransactionTypeUserRepo(_context);
            }
        }
        public IUsersRepo UsersRepo
        {
            get
            {
                return _usersRepo = _usersRepo ?? new UsersRepo(_context);
            }
        }
        public IWalletsRepo WalletsRepo
        {
            get
            {
                return _walletsRepo = _walletsRepo ?? new WalletsRepo(_context);
            }
        }
     
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
