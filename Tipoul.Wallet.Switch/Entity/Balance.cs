using System.Numerics;

namespace Tipoul.Wallet.Switch.Entity
{
    public class Balance
    {
        public long Id { get; set; }
        public long ?WalletId { get; set; }
        public long ?Amount { get; set; }        
        public long ?AmountSettlementable { get; set; }
        
       
    }
}
