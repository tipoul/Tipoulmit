using System.Numerics;

namespace Tipoul.Wallet.Switch.Entity
{
    public class TransactionDetail
    {
        public long Id { get; set; }
        
        public string ?ProductName { get; set; }
        public int ?Number { get; set; }
        public int ?Offer { get; set; }
        public int ?Price { get; set; }
        public int ?ItemStatus { get; set; }
        public string ?Description { get; set; }
    }
}
