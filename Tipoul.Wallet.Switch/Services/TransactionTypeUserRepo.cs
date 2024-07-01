using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Infrastructure;

namespace Tipoul.Wallet.Switch.Services
{
    public class TransactionTypeUserRepo : ITransactionTypeUserRepo
    {
        private SwitchWalletContext _context;
        public TransactionTypeUserRepo(SwitchWalletContext context)
        {
            _context = context;
        }
        public TransactionTypeUser GetById(long id)
        {
            var TransactionTypeUser = _context.TransactionTypeUser.Where(x => x.Id == id).FirstOrDefault();
            return TransactionTypeUser;
        }
        public TransactionTypeUser GetByTypeUser(long TransactionTypeId,long UserId)
        {
            var Objs = _context.TransactionTypeUser.Where(x => x.TransactionTypeId == TransactionTypeId && x.UserId== UserId).FirstOrDefault();
            return Objs;
        }
    }
}
