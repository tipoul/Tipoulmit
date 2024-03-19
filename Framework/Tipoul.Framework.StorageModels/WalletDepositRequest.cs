using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.StorageModels
{
    public class WalletDepositRequest
    {
        public WalletDepositRequest()
        {
            CreateDate = DateTime.Now;
            WalletDepositRequestStatusHistories = new List<WalletDepositRequestStatusHistory>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WalletId { get; set; }
        public long Amount { get; set; }
        public long AmountAfterDeposit { get; set; }
        public string TransactionTrace { get; set; }
        public string TransactionDate { get; set; }
        public string SourceOwnerName { get; set; }
        public string? SourceOwnerNationalCode { get; set; }
        public string SourceBank { get; set; }
        public string SourceAcountNumber { get; set; }
        public string SourceIbanNumber { get; set; }
        public string? DestIbanNumber { get; set; }
        public string? DepositerName { get; set; }
        public string? DepositerNationalCode { get; set; }
        public string DepositType { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string? ConfirmDescription { get; set; }
        public User User { get; set; }
        public Wallet Wallet { get; set; }
        public List<WalletDepositRequestStatusHistory> WalletDepositRequestStatusHistories { get; set; }
    }
}
