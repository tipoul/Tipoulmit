using Tipoul.Wallet.Switch.Data;
using Tipoul.Wallet.Switch.Entity;
using Tipoul.Wallet.Switch.Infrastructure;

namespace Tipoul.Wallet.Switch.Services
{
    public class TransactionTypesRepo : ITransactionTypesRepo
    {
        private SwitchWalletContext _context;
        public TransactionTypesRepo(SwitchWalletContext context)
        {
            _context = context;
        }
        public TransactionTypes GetById(long id)
        {
            var TransactionTypes = _context.TransactionTypes.Where(x => x.Id == id).FirstOrDefault();
            return TransactionTypes;
        }
        public TransactionTypes GetByTitle(string Title)
        {
            return _context.TransactionTypes.Where(x => x.Title.Contains(Title)).FirstOrDefault();           
           
        }
    }
}
