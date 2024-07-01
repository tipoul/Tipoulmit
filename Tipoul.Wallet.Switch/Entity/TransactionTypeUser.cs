using System.Numerics;

namespace Tipoul.Wallet.Switch.Entity
{
    public class TransactionTypeUser
    {
        public long Id { get; set; }
        public long ?TransactionTypeId { get; set; }
        public long ?UserId { get; set; }
        public double ?Wage { get; set; }
        public int ?MaxWage { get; set; }
        public double ? UserRate { get; set; }
        public long ?Partner { get; set; }
        public float? PartnerRate { get; set; }
        public float? TipoulRate { get; set; }

        //public virtual TransactionTypes TransactionTypes { get; set; }
    }
}
