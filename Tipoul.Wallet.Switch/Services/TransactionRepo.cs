using Microsoft.EntityFrameworkCore;
using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Infrastructure;

namespace Tipoul.Wallet.Switch.Services
{
    public class TransactionRepo : ITransactionRepo
    {
        private SwitchWalletContext _context;
        public TransactionRepo(SwitchWalletContext context)
        {
            _context = context;
        }
        public Transactions GetById(long id)
        {
            var Transaction = _context.Transactions.Where(x => x.Id == id).FirstOrDefault();
            return Transaction;
        }
        public Transactions GetByWTTN(string WTTN)
        {
            var Transaction = _context.Transactions.Where(x => x.WTTN == WTTN).FirstOrDefault();
            return Transaction;
        }
        public OperationResult Insert(Transactions transaction)
        {
            var res = _context.Transactions.Add(transaction);

            if (res.State == EntityState.Added)
                return OperationResult.Success();

            else return OperationResult.Error();
        }
    }
}
