using System;

namespace Tipoul.UserPanel.WebUI.Models.Report.WalletDepositRequests
{
    public class WalletDepositRequestsListItemViewModel
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public long AmountAfterDeposit { get; set; }
        public string TransactionTrace { get; set; }
        public string TransactionDate { get; set; }
        public string SourceOwnerName { get; set; }
        public string SourceIbanNumber { get; set; }
        public string SourceBank { get; set; }
        public string SourceOwnerNationalCode { get; set; }
        public string DestIbanNumber { get; set; }
        public string DepositerName { get; set; }
        public string DepositerNationalCode { get; set; }
        public string DepositType { get; set; }
        public string Description { get; set; }
        public string Wallet { get; set; }
        public string LastStatus { get; set; }
        public string CreateDate { get; set; }
        public string ConfirmDate { get; set; }
        public string ConfirmDescription { get; set; }
    }
}
