using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class Settlement
    {
        public Settlement()
        {
            CreateDate = DateTime.Now;
            SelectedDate = DateTime.Today.AddDays(1);
            SettlementStatusHistories = new List<SettlementStatusHistory>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int WalletId { get; set; }
        public int BankAccountId { get; set; }
        public int? UserWageHistoryId { get; set; }
        public long Amount { get; set; }
        public long AmountInTipoulAfterSettlement { get; set; }
        public long AmountInBankAfterSettlement { get; set; }
        public DateTime SelectedDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string? OwnerName { get; set; }
        public string? AccountNumber { get; set; }
        public string? IbanNumber { get; set; }
        public string? CardNumber { get; set; }
        public string? NationalCode { get; set; }
        public string? Babat { get; set; }
        public string? Sharh { get; set; }
        public string? Bank { get; set; }
        public string? TransferType { get; set; }
        public string? TraceNumber { get; set; }
        public string? DocutmentURL { get; set; }
        public string? PaymentID { get; set; }
        public User User { get; set; }

        public Wallet Wallet { get; set; }
        public bool QuickSettlement { get; set; }
        public string? RequestedUuid { get; set; }
        public BankAccount BankAccount { get; set; }

        public UserWageHistory? UserWageHistory { get; set; }

        public List<SettlementStatusHistory> SettlementStatusHistories { get; set; }
    }
}
