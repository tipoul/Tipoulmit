using System.Collections.Generic;
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;
using Tipoul.Framework.Utilities.Enums;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Models
{
    public class QuickSettlementResultModel
    {
        public string ownerName { get; set; }
        public string ibanNumber { get; set; }
        public string accountNumber { get; set; }
        public string cardNumber { get; set; }
        public string nationalCode { get; set; }
        public string time { get; set; }
        public long amount { get; set; }
        public BankEnum bank { get; set; }
        public TransferTypeEnum transferType { get; set; }
        public BabatEnum babat { get; set; }
        public string sharh { get; set; }
        public string paymentID { get; set; }
        public int walletId { get; set; }
    }
}
