using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Infrastructure;

namespace Tipoul.Wallet.Switch.Services
{
    public class TransactionDetailRepo : ITransactionDetailRepo
    {
        private SwitchWalletContext _context;
        public TransactionDetailRepo(SwitchWalletContext context)
        {
            _context = context;
        }
        public TransactionDetail GetById(long id)
        {
            var TransactionDetail = _context.TransactionDetail.Where(x => x.Id == id).FirstOrDefault();
            return TransactionDetail;
        }
    }
}
