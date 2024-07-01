using System.Numerics;

namespace Tipoul.Wallet.Switch.Entity
{
    public class Transactions
    {
        public long Id { get; set; }
        public string ?WTTN { get; set; }
        public long ?SourceWalletId { get; set; }
        public long ?DestinationWalletId { get; set; }
        public long ?TransactionTypeUserId { get; set; }
        public long ?FactorNo { get; set; }
        public long ?BlankForOrder { get; set; }        
        public long ?Amount { get; set; }
        public long ?EndUserWageAmount { get; set; }
        public long ?UserWageAmount { get; set; }       
            
        public long ?WageAmount { get; set; }        
        public long ?Amountpayable { get; set; }
        public double ?Offer { get; set; }
        public DateTime RegisterDate { get; set; }
        public int ?ResultStatus { get; set; }     
        public string ?WTTRN { get; set; }
        public int ?IsWage { get; set; }

    }
}
