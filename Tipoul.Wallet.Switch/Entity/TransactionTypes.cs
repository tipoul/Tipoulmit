using System.Numerics;

namespace Tipoul.Wallet.Switch.Entity
{
    public class TransactionTypes
    {
        public long Id { get; set; }
       
        public string ?Title { get; set; }
        public string ?Images { get; set; }
        public string ?Description { get; set; }
       
        //protected internal List<TransactionTypeUser> TransactionTypeUsers { get; private set; }
        //public virtual BalanceType BalanceTypes { get; set; }
    }
}
