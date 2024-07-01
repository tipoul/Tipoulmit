using System.Numerics;

namespace Tipoul.Wallet.Switch.Entity
{
    public class Wallets
    {
        public long Id { get; set; }
        
        public string ?Title { get; set; }
        public long ?UserId { get; set; }
        public string? Payurl { get; set; }
        public DateTime ?RegisterDate { get; set; }
        public int ?WalletNo { get; set; }
        public Boolean ?FlagDefault { get; set; }

        

    }
}
